using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEditor.UI;
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
    private Vector3 move;
    private bool groundedPlayer = true;
    private uint jumpMax = 1;
    private uint jumpTimes = 0;

    private void Start()
    {
        
    }

    void Update()
    {
        Strafe();

        // applying gravity
        playerVelocity.y -= gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        Jump();
    }

    void Strafe()
    {
        move = (transform.right * Input.GetAxis("Horizontal")) + (transform.forward * Input.GetAxis("Vertical"));

        controller.Move(move * Time.deltaTime * playerSpeed);
    }

    void Jump()
    {
        if (controller.isGrounded)
        {
            groundedPlayer = true;
            jumpTimes = 0;
        }
        if (Input.GetButtonDown("Jump") && groundedPlayer && jumpTimes < jumpMax)
        {
            playerVelocity.y = jumpHeight;
            groundedPlayer = false;
            jumpTimes++;
        }    
    }
}
