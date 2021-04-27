using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeDoor : SimpleDoorMove
{
    public bool isLocked = true;
    // Start is called before the first frame update

    private void OnMouseOver()
    {
        if (ValidatePlayerClick())
            if(!isLocked)
            {
                StartCoroutine(MoveDoor());
            }
            else
            {
                Debug.Log("Door is locked, place badges in the correct order at the right side");
            }
    }

    public void UnlockDoor()
    {
        Debug.Log("Office Door Unlocked");
        isLocked = false;
        StartCoroutine(MoveDoor());
    }
}
