using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_Behaviour : MonoBehaviour
{
    private Rigidbody body;
    [SerializeField] private float moveForce, jumpForce;
    [SerializeField] private bool isGrounded = true;
    private Vector3 jump;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jumpForce, 0.0f);
    }


    void Update()
    {
        Roll();
        Jump();
    }

    public void Roll()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        body.AddForce(Vector3.forward * Time.deltaTime * moveForce * horizontal);
        body.AddForce(Vector3.right * Time.deltaTime * moveForce * vertical);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true; //jump
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false; //jump
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true) 
        {
            body.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }
}
