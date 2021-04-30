using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightSwitcher : InteractiveActions
{

    [SerializeField] GameObject lights;
    public bool isLightOn = false;

    private void OnMouseOver()
    {
        if (ValidatePlayerClick())
        {
            if (isLightOn)
            {
                lights.SetActive(!lights.activeSelf);
            }
            else
            {
                SendUIMessage("Nothing Happened");
            }
            PlayAudio();

        }

    }
}