using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PMovment : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    private bool isGrounded;
    public float gravity = -9.8f;
    public float speed = 5f;
    public float jumpHeight = 3f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 Input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = Input.x;
        moveDirection.z = Input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
        Debug.Log("DEBUG : Players y axis power : " + playerVelocity.y);

    }

    public void Jump()
    {
        playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
    }
}
