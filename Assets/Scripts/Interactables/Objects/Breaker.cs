using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : InteractiveActions
{
    [SerializeField] int breakerindex;
    BreakerController fuseboxScript;

    private void Start()
    {
        fuseboxScript = transform.GetComponentInParent<BreakerController>();
    }

    private void OnMouseOver()
    {

        if (ValidatePlayerClick())
        {
            transform.rotation = fuseboxScript.SwitchBreaker(breakerindex);
            PlayAudio();
        }
    }

}
