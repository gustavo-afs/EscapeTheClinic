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
                SendUIMessage("Door is locked, place badges in the correct order at the right side");
            }
    }

    public void UnlockDoor()
    {
        SendUIMessage("Office Door Unlocked");
        isLocked = false;
        StartCoroutine(MoveDoor());
    }
}
