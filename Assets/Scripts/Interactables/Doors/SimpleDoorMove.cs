using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDoorMove : InteractiveActions
{
    protected bool isClosed = true;
    Collider doorCollider;
    Animator doorAnimator;

    void Start()
    {
        doorCollider = gameObject.GetComponent<Collider>();
        doorAnimator = gameObject.GetComponent<Animator>();
    }

    private void OnMouseOver()
    {
        if (ValidatePlayerClick())
            StartCoroutine(MoveDoor());
    }
 
    protected IEnumerator MoveDoor()
    {
        doorCollider.enabled = false;
        if (isClosed)
        {
            doorAnimator.Play("Opening 1");
            isClosed = false;
        }
        else
        {
            doorAnimator.Play("Closing 1");
            isClosed = true;
        }

        yield return new WaitForSeconds(.8f);
        doorCollider.enabled = true;
    }
}
