using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveActions : MonoBehaviour
{
    GameObject player;
    GameObject playerHand;
    Vector3 playerHandPosition;
    Text outputField;
    AudioSource audioSource;


    void Awake()
    {
        player = GameObject.Find("Player");
        playerHand = GameObject.FindGameObjectWithTag("Hand");
        outputField = GameObject.Find("OutputField").GetComponent<Text>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    protected void GrabItem(GameObject itemObject)
    {
        if (itemObject)
        {
            playerHandPosition = playerHand.transform.position;
            itemObject.GetComponent<Collider>().enabled = false;
            itemObject.transform.position = playerHandPosition;
            itemObject.transform.parent = playerHand.transform;
            itemObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f); 
        }
    }

    protected bool ValidatePlayerClick()
    {
        if (player & (Vector3.Distance(transform.position, player.transform.position) < 5) & Input.GetMouseButtonDown(0))
            return true;
        else
            return false;
    }

    protected GameObject HoldingItem()
    {
        if (playerHand.transform.childCount > 0)
            return playerHand.transform.GetChild(0).gameObject;
        else
            return null;
    }

    protected void DestroyUsedObject()
    {
        GameObject.Destroy(HoldingItem());
    }

    protected void DropObjectTo(GameObject itemObject)
    {
        GameObject handedItem = HoldingItem();
        handedItem.GetComponent<Collider>().enabled = true;
        handedItem.transform.parent = itemObject.transform.parent;
        handedItem.transform.position = itemObject.transform.position;
    }

    protected bool KeyUnlock(int lockIndex)
    {
        if (HoldingItem())
        {
            if (HoldingItem().TryGetComponent<SimpleKey>(out var simpleKeyComponent))
            {
                if (simpleKeyComponent.keyIndex == lockIndex) //If it`s the correct key
                {
                    DestroyUsedObject();
                    SendUIMessage("Unlocked!");
                    return true;
                }
                else //if it`s the wrong key
                {
                    SendUIMessage("Wrong Key");
                }
            }
            else //if it`s holding any other object
            {
                SendUIMessage("Nothing Happened");
            }
        }
        else //if the hand is empty
        {
            SendUIMessage("It's locked");
        }
        return false;
    }

    protected void SendUIMessage(string message)
    {
        outputField.text = message;
        StartCoroutine(HideMessage());
    }

    IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(2f);
        outputField.text = "";
    }

    protected void PlayAudio(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    protected void PlayAudio()
    {
        audioSource.Play();
    }
}
