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
    [SerializeField] GameManager gameManager;


    private void Start()
    {
        director = GetComponent<PlayableDirector>();
    }
    private void OnMouseOver()
    {
        if (!introStarted)
        {
            if (ValidatePlayerClick())
            {
                director.Play();
                introStarted = true;
            }
        }
        else if (director.state != PlayState.Playing)
        {
            environment.SetActive(true);
            playerMove.enabled = true;
            gameManager.enabled = true;
            Destroy(gameObject);
        }
    }
}
