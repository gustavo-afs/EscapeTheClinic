using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] float playerSpeed = 1f;

    CharacterController playerController;

    void Start()
    {
        //Automatically assigning the CharacterController component
        playerController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float
            moveX = Input.GetAxis("Horizontal"),
            moveZ = Input.GetAxis("Vertical");
        Vector3 playerMoveValues = transform.right * moveX + transform.forward * moveZ;
        playerController.Move(playerMoveValues * playerSpeed * Time.deltaTime);
    }
}
