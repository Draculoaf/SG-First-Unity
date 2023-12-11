using UnityEngine;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class SaveValues
{
    [JsonProperty("collectables_number")] public int collectNum;
    [JsonProperty("can_jump")] public bool canJump;
    [JsonProperty("character_pos")] public Vector3 char_pos;
}

public class SaveManager : MonoBehaviour
{
    public mannager_Collectables collectScript;
    public ball_Behaviour ballScript;

    public string dataPath = "";

    //Create or overwrite the values in the "saveValues"
    private SaveValues _saveValues = new SaveValues();


    void Start()
    {
        collectScript = FindObjectOfType<mannager_Collectables>();
        ballScript = FindObjectOfType<ball_Behaviour>();

        //Where is the data path
        dataPath = Application.persistentDataPath + "/" + "my_save_values.json";
        Debug.Log("DATA IS IN: " + dataPath);
    }


    void Update()
    {
        //Update the value when it happens in game
        if (collectScript != null)
        {
            _saveValues.collectNum = collectScript.collect;
            _saveValues.canJump = ballScript.canJump;
            _saveValues.char_pos = ballScript.transform.position;
        }

        //Write the data in
        writeDataToFile();

        //Read the data & tell me what it is
        SaveValues newValues = readDataToFile();
        Debug.Log("collectables you have: " + newValues.collectNum);
    }

    public void writeDataToFile()
    {
        //Write the data and ignore self referencing loops
        string output = JsonConvert.SerializeObject(_saveValues, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        System.IO.File.WriteAllText(dataPath, output);
    }

    public SaveValues readDataToFile()
    {
        string jsonData = System.IO.File.ReadAllText(dataPath);
        return JsonConvert.DeserializeObject<SaveValues>(jsonData);
    }

}
