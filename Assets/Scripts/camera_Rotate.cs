using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_Rotate : MonoBehaviour
{
   [SerializeField]
   private float rotateSpeed, x, y;


    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
 
    public void Update()
    {
        CameraRotate();
    }


    public void CameraRotate()
    {
        y = Input.GetAxis("Mouse X");

        x = Input.GetAxis("Mouse Y");

        transform.Rotate(x * rotateSpeed, y, 0);
    }
}
