using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opencloseDoor1: MonoBehaviour {

	public Animator openandclose1;
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
							Debug.Log("Door Move is now true");
							doorCollider.enabled = false;
							StartCoroutine (opening ());

						}
					} else {
						if (open == true) {
							if (Input.GetMouseButtonDown (0)) {
								Debug.Log("Door Move is now true");
								doorCollider.enabled = false;
								StartCoroutine (closing ());


							}
						}
						
					}
					
				}
			}

		}

	}

	IEnumerator opening(){
		print ("you are opening the door");
		openandclose1.Play ("Opening 1");
		open = true;
		yield return new WaitForSeconds (.5f);
		doorCollider.enabled = true;
		Debug.Log("Door Move is now false");
	}

	IEnumerator closing(){
		print ("you are closing the door");
		openandclose1.Play ("Closing 1");
		open = false;
		yield return new WaitForSeconds (.5f);
		doorCollider.enabled = true;
		Debug.Log("Door Move is now false");
	}
}

