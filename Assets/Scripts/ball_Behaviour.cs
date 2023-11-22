using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ball_Behaviour : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float moveForce, jumpForce;
    [SerializeField] private bool isGrounded = true;
    private Vector3 jump;
    //public GameObject player;
    

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
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

        //Bronwin's solution
        //Vector3 moveDirection = transform.forward * vertical + transform.right * horizontal;
        //rb.AddForce(moveDirection.normalized * moveForce * 10f, ForceMode.Force);

        //My solution
        rb.AddForce(Vector3.forward * Time.deltaTime * moveForce * horizontal);
        rb.AddForce(Vector3.right * Time.deltaTime * moveForce * vertical);
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true; 
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false; 
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true) 
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }
}
