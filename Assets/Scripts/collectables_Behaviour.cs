using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class collectables_Behaviour : MonoBehaviour
{
      private void OnTriggerEnter(Collider other)
    {
        
       if (other.tag == "Player")
        {

            //Delete collected items
            Destroy(this.gameObject);  
        }
    }
}
