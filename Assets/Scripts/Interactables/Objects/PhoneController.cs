using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PhoneController : InteractiveActions
{
    private PlayableDirector director;
    private PlayableAsset playableAsset;
    bool introStarted = false;
    [SerializeField] PlayerMove playerMove;
    [SerializeField] GameObject environment;
    [SerializeField] LifeController lifeController;


    private void Start()
    {
        director = GetComponent<PlayableDirector>();
    }
    private void OnMouseOver()
    {
        
        if (ValidatePlayerClick())
        {
            if(!introStarted)
            { 
            director.Play();
            introStarted = true;
            }
            else
            {
                if (director.state != PlayState.Playing )
                {
                    Debug.Log("is not playing...");
                    environment.SetActive(true);
                    playerMove.enabled = true;
                    lifeController.enabled = true;
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("is playing!");
                }
            }
        }
    }
}
