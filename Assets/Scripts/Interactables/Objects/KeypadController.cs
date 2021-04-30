using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadController : InteractiveActions
{

    bool isLocked = true;
    int lockIndex = 1;
    [SerializeField] GameObject keyPadCover;
    [SerializeField] Collider2D[] keypadColliders;
    [SerializeField] TextMesh ouputText;
    [SerializeField] GameManager gameManager;
    string password = "";

    private void Start()
    {
        ChangeColliderStatus(keypadColliders, false);
    }

    private void OnMouseOver()
    {
        if (ValidatePlayerClick())
        {
            if (isLocked)
            {
                if (KeyUnlock(lockIndex))
                {
                    isLocked = false;
                    keyPadCover.transform.localRotation = new Quaternion(0.0f, 0.8f, 0.0f, 0.6f);
                    gameObject.GetComponent<Collider>().enabled = false;
                    ChangeColliderStatus(keypadColliders, true);
                }
            }
        }
    }

    public void KeyInput(string inputValue)
    {
        switch (inputValue)
        {
            case "C":
                password = "";
                break;
            case "S":
                VerifyPassword();
                break;
            default:
                if (password.Length < 4)
                password += inputValue;
                break;
        }
        ouputText.text = password;
    }

    void ChangeColliderStatus(Collider2D[] collider, bool status)
    {
        
        for(int i = 0; i < collider.Length; i++)
        {
            collider[i].enabled = status;
        }
    }

    void VerifyPassword()
    {
        if (password == "4913")
        {
            SendUIMessage("YOU ESCAPED IN TIME!");
            gameManager.PauseRequest(true);
            gameManager.resumeButton.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            password = "";
            SendUIMessage("Wrong Password");
        }
    }
}
