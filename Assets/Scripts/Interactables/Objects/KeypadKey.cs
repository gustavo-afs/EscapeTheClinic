using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadKey : InteractiveActions
{
    [SerializeField] string keyValue;
    KeypadController keypadController;
    // Start is called before the first frame update
    void Start()
    {
        keypadController = gameObject.GetComponentInParent<KeypadController>();
    }

    private void OnMouseOver()
    {
        if (ValidatePlayerClick())
        {
            keypadController.KeyInput(keyValue);
        }
    }
}
