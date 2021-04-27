using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badge : InteractiveActions
{
    public int index;

    private void OnMouseOver()
    {
        if (ValidatePlayerClick())
        {
            if (HoldingItem())
            {
                DropObjectTo(gameObject);
            }
            GrabItem(gameObject);
        }
    }
}
