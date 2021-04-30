using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomDoor : SimpleDoorMove
{
    bool isLocked = true;
    int lockIndex = 0;
    [SerializeField] AudioClip unlockDoor;

    private void OnMouseOver()
    {
        if (ValidatePlayerClick())
        {
            if (isLocked)
            {
                if (KeyUnlock(lockIndex))
                {
                    isLocked = false;
                    StartCoroutine(MoveDoor());
                    SendUIMessage("Bedroom Door Unlocked");
                    PlayAudio(unlockDoor);
                }
            }
            else
            {
                StartCoroutine(MoveDoor());
            }
        }

    }
}
