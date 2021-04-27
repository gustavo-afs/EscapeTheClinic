using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadController : InteractiveActions
{

    bool isLocked = true;
    int lockIndex = 1;
    [SerializeField] GameObject keyPadCover;
    [SerializeField] Collider2D[] keypadColliders;
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
                Debug.Log("Cancel");
                password = "";
                break;
            case "S":
                Debug.Log("Submit");
                VerifyPassword();
                break;
            default:
                Debug.Log("Input: " + inputValue);
                if (password.Length < 4)
                password += inputValue;
                Debug.Log("Password: " + password);
                break;
        }

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
        if (password == "1234")
        {
            Debug.Log("VICTORY");
        }
        else
        {
            password = "";
            Debug.Log("Wrong Password");
        }
    }
}
