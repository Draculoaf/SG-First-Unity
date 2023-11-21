using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_Roll : MonoBehaviour
{
    private Rigidbody body;
    [SerializeField] private float moveForce;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        Roll();
    }

    public void Roll()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        body.AddForce(Vector3.right * Time.deltaTime * moveForce * horizontal);
        body.AddForce(Vector3.forward * Time.deltaTime * moveForce * vertical);
    }
}
