using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;


public enum tileType {
air, 
water, 
lava,
stone
}

[Serializable]
public class world
{
    [JsonProperty("map_size")] public int mapSize = 32;

    [JsonProperty("character_pos")] public Dictionary<string, Vector3> characterPos = new Dictionary<string, Vector3>();

    [JsonProperty("building_pos")] public Dictionary<string, Vector3> buildingPos = new Dictionary<string, Vector3>();

    [JsonProperty("tile_cords")] public Dictionary<string, tileType> tileCords = new Dictionary<string, tileType>();
}

public class customJSON : MonoBehaviour
{
    public string dataPath = "";
    private world _world = new world();
    
    void Start()
    {
        BuildRandomData();
        
        dataPath = Application.persistentDataPath + "/" + "my_world.json";
        Debug.Log("DATA IS IN: " + dataPath);
        
        writeDataToFile();
        
        world newWorld = readDataToFile();
        

        Debug.Log("map size: " + newWorld.mapSize);
        Debug.Log("map data: " + newWorld.tileCords[newWorld.tileCords.Keys.First()]);
        Debug.Log("character pos: " + newWorld.characterPos[newWorld.characterPos.Keys.First()]);
        Debug.Log("building positions: " + newWorld.buildingPos[newWorld.buildingPos.Keys.First()]);
    }

    private void BuildRandomData()
    {
        //map tiles
        for (int x = 0; x < _world.mapSize; x++)
        {
            for (int y = 0; y < _world.mapSize; y++)
            {
                int randomNumber = UnityEngine.Random.Range(1, 5);
                tileType tileType = tileType.air;
                switch (randomNumber)
                {
                    case 1: tileType = tileType.stone;
                        break;
                    case 2: tileType = tileType.lava;
                        break;
                    case 3: tileType = tileType.water;
                        break;
                    case 4: tileType = tileType.air;
                        break;
                    default:
                        break;
                }

                _world.tileCords.Add(x + "|" + y, tileType);
                
            }
        }

        //place people and buildings
        _world.characterPos.Add("simon", new Vector3(UnityEngine.Random.Range(0, 32), 1, UnityEngine.Random.Range(0, 32)));
        _world.characterPos.Add("jess",
            new Vector3(UnityEngine.Random.Range(0, 32), 1, UnityEngine.Random.Range(0, 32)));
        
        _world.buildingPos.Add("home",
            new Vector3(UnityEngine.Random.Range(0, 32), 1, UnityEngine.Random.Range(0, 32)));
        _world.buildingPos.Add("bakery",
            new Vector3(UnityEngine.Random.Range(0, 32), 1, UnityEngine.Random.Range(0, 32)));
    }

    public void writeDataToFile()
    {
        string output = JsonConvert.SerializeObject(_world, new JsonSerializerSettings{ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
        System.IO.File.WriteAllText(dataPath,output);
    }

    public world readDataToFile()
    {
        string jsonData = System.IO.File.ReadAllText(dataPath);
        return JsonConvert.DeserializeObject<world>(jsonData);
    }
}
