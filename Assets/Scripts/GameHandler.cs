using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private InputField saveLevelName, loadLevelName;
    [SerializeField] private Text SaveLoadMessage;
    private LevelData level;
    [SerializeField]private GameObject platform, coin, startPoint, endPoint, playerSpawner, loadLevelMenu;

    // Start is called before the first frame update
    void Start()
    {
        CreateLevelData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    LevelData CreateLevelData()
    {
        level = new LevelData();
        level.objectData = new List<SpawnableObjectData.Data>();
        return level;
    }

    public void SaveLevel()
    {
        SpawnableObjectData[] Objectsfound = FindObjectsOfType<SpawnableObjectData>();
        foreach (SpawnableObjectData obj in Objectsfound)
            level.objectData.Add(obj.data);

        string json = JsonUtility.ToJson(level);
        string folder = Application.dataPath + "/SavedData";
        string levelFile = "";

        if (saveLevelName.text == "")
            levelFile = "new_level.json";
        else
            levelFile = saveLevelName.text + ".json";
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);
        string path = Path.Combine(folder, levelFile);

        if (File.Exists(path))
            File.Delete(path);
        File.WriteAllText(path, json);
        saveLevelName.text = "";
        saveLevelName.DeactivateInputField();
        SaveLoadMessage.text = levelFile + " Saved !!";
    }

    public void LoadLevel()
    {
        playerSpawner.SetActive(true);
        loadLevelMenu.SetActive(false);
        string folder = Application.dataPath + "/SavedData";
        string levelfile = "";
        if (loadLevelName.text == "")
            levelfile = "new_level.json";
        else
            levelfile = loadLevelName.text + ".json";

        string path = Path.Combine(folder, levelfile);

        if (File.Exists(path))
        {
            SpawnableObjectData[] Objectsfound = FindObjectsOfType<SpawnableObjectData>();
            foreach (SpawnableObjectData obj in Objectsfound)
                Destroy(obj.gameObject);
          
            string json = File.ReadAllText(path);
            level = JsonUtility.FromJson<LevelData>(json);
            InstantiateLevel();
        }
        else
        {
            SaveLoadMessage.text = levelfile + " Doesn't Exist";
            loadLevelName.DeactivateInputField();
        }
    }

    void InstantiateLevel()
    {
        GameObject newObject;
        for (int i = 0; i < level.objectData.Count; i++)
        {
            if (level.objectData[i].objectType == SpawnableObjectData.DataType.platform)
            {
                newObject = Instantiate(platform, level.objectData[i].position, Quaternion.identity);
                

                SpawnableObjectData spawnableObj = newObject.AddComponent<SpawnableObjectData>();
                spawnableObj.data.position = newObject.transform.position;
                spawnableObj.data.objectType = SpawnableObjectData.DataType.platform;
            }

            else if (level.objectData[i].objectType == SpawnableObjectData.DataType.coin)
            {
                newObject = Instantiate(coin, level.objectData[i].position, Quaternion.identity);
                

                SpawnableObjectData spawnableObj = newObject.AddComponent<SpawnableObjectData>();
                spawnableObj.data.position = newObject.transform.position;
                spawnableObj.data.objectType = SpawnableObjectData.DataType.coin;
            }

            

            else if (level.objectData[i].objectType == SpawnableObjectData.DataType.startPos)
            {
                newObject = Instantiate(startPoint, level.objectData[i].position, Quaternion.identity);
                

                SpawnableObjectData spawnableObj = newObject.AddComponent<SpawnableObjectData>();
                spawnableObj.data.position = newObject.transform.position;
                spawnableObj.data.objectType = SpawnableObjectData.DataType.startPos;
            }

            else if (level.objectData[i].objectType == SpawnableObjectData.DataType.endPos)
            {
                newObject = Instantiate(endPoint, level.objectData[i].position, Quaternion.identity);
                 
             
                SpawnableObjectData spawnableObj = newObject.AddComponent<SpawnableObjectData>();
                spawnableObj.data.position = newObject.transform.position;
                spawnableObj.data.objectType = SpawnableObjectData.DataType.endPos;
            }
        }
        loadLevelName.text = "";
        loadLevelName.DeactivateInputField();
        SaveLoadMessage.text = " Loaded !!";
    }

}
