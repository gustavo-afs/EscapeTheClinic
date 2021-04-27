using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openclosedouble: MonoBehaviour {

	public Animator openandclose;
	public bool open, isMoving;
	public Transform Player;
	Collider doorCollider;

	void Start (){
		open = false;
		isMoving = false;
		doorCollider = gameObject.GetComponent<Collider>();
	}

	void OnMouseOver (){
		{
			if (Player) {
				float dist = Vector3.Distance (Player.position, transform.position);
				if (dist < 15) {
					if (open == false) {
						if (Input.GetMouseButtonDown (0)) {
							isMoving = true;
							Debug.Log("Door Move is now true");
							StartCoroutine (opening ());
						}
					} else {
						if (open == true) {
							if (Input.GetMouseButtonDown (0)) {
								isMoving = true;
								Debug.Log("Door Move is now true");
								StartCoroutine (closing ());
							}
						}
						isMoving = false;
						Debug.Log("Door Move is now false");
					}

				}
			}

		}

	}

	IEnumerator opening(){
		print ("you are opening the door");
		openandclose.Play ("ddopen");
		open = true;
		yield return new WaitForSeconds (.5f);
	}

	IEnumerator closing(){
		print ("you are closing the door");
		openandclose.Play ("ddclose");
		open = false;
		yield return new WaitForSeconds (.5f);
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject == Player)
		{
			doorCollider.isTrigger = false;
			Debug.Log("Player exit the Collision trigger, setting to isTrigger to false");
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (isMoving & collision.gameObject == Player)
		{
			Debug.Log("Player is Colliding. Changing Collision to trigger");
			doorCollider.isTrigger = true;
		} else
		Debug.Log("Something else collided here: " + collision);
	}

}

