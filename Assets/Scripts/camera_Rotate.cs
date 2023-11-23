using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_Rotate : MonoBehaviour
{
   [SerializeField]
   private float rotateSpeed, x, y;
    public Transform target;
    public GameObject targetGameObject;


    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
 
    public void Update()
    {
        //CameraRotate();
    }


    public void CameraRotate()
    {
        y = Input.GetAxis("Mouse X");

        x = Input.GetAxis("Mouse Y");

        transform.Rotate(x * rotateSpeed, y, 0);

        transform.position=targetGameObject.transform.position;
        //transform.RotateAround(targetGameObject.transform.position, Vector3.up, 20 * Time.deltaTime);
        //transform.RotateAround(targetGameObject.transform.position, Vector3.right, rotateSpeed);
    }
}
