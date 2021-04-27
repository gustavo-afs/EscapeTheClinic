using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleKey : InteractiveActions 
{
    public int keyIndex;
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
