using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerController : InteractiveActions
{
    //Vector breakers
    Quaternion
        openBreaker,    //The false value at the Vector
        closedBreaker; //The true value at the Vector

    //Breakers state
    bool[] controlBreaker = new bool[5];

    //RedLightSwitcher
    [SerializeField] RedLightSwitcher redLight;
    [SerializeField] GameObject mriLights;

    void Start()
    {
        openBreaker = new Quaternion(0.4f, 0.0f, 0.0f, 0.9f);
        closedBreaker = new Quaternion(-0.3f, 0.0f, 0.0f, 1.0f);
        mriLights.SetActive(false);
    }

    public Quaternion SwitchBreaker(int index)
    {
        controlBreaker[index] = !controlBreaker[index];
        ConfirmSequence();
        //Checking inverted because it was already replaced
        if (!controlBreaker[index])
        {
            return openBreaker;
        }
        else
        {
            return closedBreaker;
        } 
    }

    void ConfirmSequence()
    {
        if (controlBreaker[0] == true & controlBreaker[1] == false & controlBreaker[2] == false & controlBreaker[3] == true & controlBreaker[4] == false)
        {
            redLight.isLightOn = true;
            SendUIMessage("Breaker Sequence Worked!");
            gameObject.GetComponent<Collider>().enabled = true;
            mriLights.SetActive(true);
            PlayAudio();
        }
    }
}
