using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_Movement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed;

    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * vertical);
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * horizontal);
    }
}
