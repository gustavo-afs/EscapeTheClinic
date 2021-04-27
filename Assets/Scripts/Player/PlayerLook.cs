using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    float rotationX = 0f;

    public Transform playerBody;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float
            mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * 550f,
            mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * 300f;

        rotationX -= mouseY; 

        rotationX = Mathf.Clamp(rotationX, -90, 90);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
