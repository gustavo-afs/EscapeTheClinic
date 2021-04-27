using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeController : MonoBehaviour
{
    int[] badgeSequence = new int[3];
    [SerializeField] OfficeDoor officeDoor;
    Collider[] badgeHolder;

    private void Start()
    {
        badgeHolder = new Collider[transform.childCount];
        for (int i = 0; i < badgeHolder.Length; i++)
        {
            badgeHolder[i] = transform.GetChild(i).gameObject.GetComponent<Collider>(); ;
        }
    }

    public void ChangeBadgeInfo(int badgeHolderIndex, int badgeIndex)
    {
        badgeSequence.SetValue(badgeIndex, badgeHolderIndex);
        ConfirmSequence();
    }

    void ConfirmSequence()
    {
        if (badgeSequence[0] == 1 & badgeSequence[1] == 2 & badgeSequence[2] == 3)
        {
            //disable all badgeHolders Collision
            officeDoor.UnlockDoor();
            for (int i = 0; i < badgeHolder.Length; i++)
            {
                badgeHolder[i].enabled = false;
            }
        }
    }

    private void Update()
    {
        //Debug.Log(badgeSequence[0] + " " + badgeSequence[1] + " " + badgeSequence[2]);
    }
}
