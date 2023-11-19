using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("----- Components -----")]
    [SerializeField] CharacterController controller;

    [Header("----- Movement Vars -----")]
    [SerializeField][Range(7.5f, 15f)] float playerSpeed;
    [SerializeField][Range(5f, 10f)] float jumpHeight;
    [SerializeField][Range(9.81f, 25f)]float gravityValue;



    private Vector3 playerVelocity;
    private bool groundedPlayer;
   
    

    private void Start()
    {
        
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            if (playerVelocity.y < 0)
                playerVelocity.y = 0f;
        }

        Vector3 move = (transform.right * Input.GetAxis("Horizontal")) + (transform.forward * Input.GetAxis("Vertical"));

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y = jumpHeight;
        }

        playerVelocity.y -= gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
