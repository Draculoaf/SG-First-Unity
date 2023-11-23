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
    public AudioSource collectablesAudioSource;
    public Image pill_1, pill_2;

    // Start is called before the first frame update
    void Start()
    {
        //collectablesTXT.text = "0/2";

        Color c = pill_1.color;
        c.a = .2f;
        pill_1.color = c;

        Color b = pill_2.color;
        b.a = .2f;
        pill_2.color = b;
    }

    // Update is called once per frame
    void Update()
    {
        //collectablesTXT.text = collect.ToString() + "/2";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "collect")
        {
            collect++;
            collectablesAudioSource.Play();

            if(collect==1)
            {
                Color c = pill_1.color;
                c.a = 1f;
                pill_1.color = c;
            }
            if (collect == 2)
            {
                Color b = pill_2.color;
                b.a = 1f;
                pill_2.color = b;
            }
        }
    }
}
