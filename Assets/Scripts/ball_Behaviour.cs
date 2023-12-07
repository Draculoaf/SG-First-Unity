using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ball_Behaviour : MonoBehaviour
{
    //Variables
    private Rigidbody rb;
    [SerializeField] private float moveForce, jumpForce;
    [SerializeField] private bool isGrounded = true, canJump = false;
    private Vector3 jump;
    [SerializeField] public GameObject deathPanel, winPanel, spacePanel;
    private mannager_Collectables collectablesScript;
    public AudioSource deathAudio, winAudio;

    
    
    
    void Start()
    {
       
        rb = gameObject.GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jumpForce, 0.0f);
        collectablesScript = GetComponent<mannager_Collectables>();      
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

    
    private void OnTriggerEnter (Collider other)
    {
        //Enable jump
        if (other.gameObject.tag == "skill_Jump")
        {
            canJump = true;
            spacePanel.SetActive(true);
            Invoke("SetFalse", 3.0f);
        }

        //Lose condition
        if (other.gameObject.tag == "death")
        {
            deathPanel.SetActive(true);
            rb.constraints = RigidbodyConstraints.FreezePosition;
            deathAudio.Play();
        }

        //Win condition
        if (other.gameObject.tag == "gate" && collectablesScript.collect >= 2)
        {
            winPanel.SetActive(true);
            rb.constraints = RigidbodyConstraints.FreezePosition;
            winAudio.Play();
            
        }
    }

    void SetFalse()
    {
        spacePanel.SetActive(false);
    }


    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && canJump == true) 
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }
}
