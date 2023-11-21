using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_GravityBody : MonoBehaviour
{
    [SerializeField]
    private Transform gravityTarget;
    public Rigidbody rb;
    public float gravity = 9.8f;
   

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        Gravity();
    }

    public void Gravity()
    {
        Vector3 diff = transform.position - gravityTarget.position;
        rb.AddForce(-diff.normalized * gravity * (rb.mass));
    }

   
}
