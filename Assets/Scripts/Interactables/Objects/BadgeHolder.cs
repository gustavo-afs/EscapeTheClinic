using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeHolder : InteractiveActions
{
    [SerializeField] int badgeHolderindex;
    Vector3 badgePosition = new Vector3(0.97f, -0.121f, -0.25f);
    [SerializeField] GameObject badgeStored;
    [SerializeField] BadgeController badgeController;

    private void Start()
    {
        badgeController = transform.GetComponentInParent<BadgeController>();
    }
    // Start is called before the first frame update

    private void OnMouseOver()
    {
        if (ValidatePlayerClick())
        {
            //If the Player is not Holding Anything
            if (!HoldingItem()) 
            {
                if (!badgeStored)
                {
                    SendUIMessage("This Badge Holder Needs a Badge");
                }
                else
                {
                    GrabItem(badgeStored);
                    //verify win condition
                    badgeStored = null;
                }
            }
            //If the Player is Holding a Badge
            else if (HoldingItem().CompareTag("Badge")) 
            {
                if (!badgeStored)
                {
                    InsertBadge(HoldingItem());
                    SendUIMessage("Badge Inserted");
                    //verify condition
                }
                else //If there`s a badge in the BadgeHolder and another badge at the player`s hand
                {
                    GameObject tempSwitchBadge = HoldingItem();
                    GrabItem(badgeStored);
                    InsertBadge(tempSwitchBadge);
                }
            }
            //If the Player is Holding any other thing that is not a badge
            else 
            {
                SendUIMessage("Nothing Happened"); 
            }
            if (badgeStored)
            {
                badgeController.ChangeBadgeInfo(badgeHolderindex, badgeStored.GetComponent<Badge>().index);
            }
            else
            {
                badgeController.ChangeBadgeInfo(badgeHolderindex, 0);
            }
        }
    }

    void InsertBadge(GameObject badgeObject)
    {
        badgeObject = HoldingItem();
        badgeObject.transform.parent = gameObject.transform;
        badgeObject.transform.localPosition = badgePosition;
        badgeObject.transform.localRotation = new Quaternion(-0.5f, -0.5f, 0.5f, 0.5f);
        badgeObject.GetComponent<Collider>().enabled = false;
        badgeStored = badgeObject;
    }
}
