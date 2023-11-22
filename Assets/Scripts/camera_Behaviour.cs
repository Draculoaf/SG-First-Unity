using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_Behaviour : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private Vector3 offset, rotate;
    private float rotateSpeed, x, y;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CameraFollow();
    }

    public void Update()
    {
        //CameraRotate(); 
    }

    public void CameraFollow()
    {
        transform.position = player.transform.position + offset;
    }

    public void CameraRotate()
    {
        y = Input.GetAxis("Mouse X");

        x = Input.GetAxis("Mouse Y");

        rotate = new Vector3(x * rotateSpeed, y, 0);
        transform.eulerAngles = transform.eulerAngles - rotate;
    }

}
