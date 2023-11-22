using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mannager_Collectables : MonoBehaviour
{
    [SerializeField]
    public Text collectablesTXT;
    public int collect = 0;
    public bool allCollectables = false;

    // Start is called before the first frame update
    void Start()
    {
        collectablesTXT.text = "0/2";
    }

    // Update is called once per frame
    void Update()
    {
        collectablesTXT.text = collect.ToString() + "/2";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "collect")
        {
            collect++;
        }
    }
}
