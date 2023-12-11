using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Linq;

[Serializable]
public class collectables
{
    [JsonProperty("collectables_value")] public int collect = 0;
}

public class CollectablesManager : MonoBehaviour
{
    [SerializeField]
    public Text collectablesTXT;

    public string dataPath = "";
    private collectables _collectables = new collectables();
    
    void Start()
    {
        //Where is the data path
        dataPath = Application.persistentDataPath + "/" + "my_collectables.json";
        Debug.Log("DATA IS IN: " + dataPath);

        //Write the data in
        writeDataToFile();
        
        //Read the data & tell me what it is
        collectables newCollectables = readDataToFile();
        Debug.Log("collectables you have: " + newCollectables.collect);
        
        //Set the text at the start
        collectablesTXT.text = "0/2";
    }

    void Update()
    {
        collectablesTXT.text = _collectables.collect.ToString() + "/2";
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "collect")
        {
            //Update number of items collected
            _collectables.collect++;
        }
    }
    
    public void writeDataToFile()
    {
        //Write the data and ignore self referencing loops
        string output = JsonConvert.SerializeObject(_collectables, new JsonSerializerSettings{ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
        System.IO.File.WriteAllText(dataPath,output);
    }

    public collectables readDataToFile()
    {
        string jsonData = System.IO.File.ReadAllText(dataPath);
        return JsonConvert.DeserializeObject<collectables>(jsonData);
    }
}
