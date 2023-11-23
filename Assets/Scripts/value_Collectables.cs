using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesManager : MonoBehaviour
{
    [SerializeField]
    public Text collectablesTXT;
    public static int collect = 0;

    void Start()
    {
        collectablesTXT.text = "0/2";
    }

    void Update()
    {
        collectablesTXT.text = collect.ToString() + "/2";
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "collect")
        {
            //Update number of items collected
            collect++;
        }
    }
}
