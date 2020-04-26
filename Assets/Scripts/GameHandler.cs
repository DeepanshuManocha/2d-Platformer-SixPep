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
        CreateEditor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    LevelData CreateEditor()
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
        string folder = Application.dataPath + "/LevelData";
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
        SaveLoadMessage.text = levelFile + " Saved to LevelData folder.";
    }

    public void LoadLevel()
    {
        playerSpawner.SetActive(true);
        loadLevelMenu.SetActive(false);
        string folder = Application.dataPath + "/LevelData";
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
            CreateFromFile();
        }
        else
        {
            SaveLoadMessage.text = levelfile + " Could not be found !";
            loadLevelName.DeactivateInputField();
        }
    }

    void CreateFromFile()
    {
        GameObject NewObject;
        for (int i = 0; i < level.objectData.Count; i++)
        {
            if (level.objectData[i].objectType == SpawnableObjectData.DataType.platform)
            {
                NewObject = Instantiate(platform, level.objectData[i].position, Quaternion.identity);
                NewObject.layer = 9;

                SpawnableObjectData eo = NewObject.AddComponent<SpawnableObjectData>();
                eo.data.position = NewObject.transform.position;
                eo.data.objectType = SpawnableObjectData.DataType.platform;
            }

            else if (level.objectData[i].objectType == SpawnableObjectData.DataType.coin)
            {
                NewObject = Instantiate(coin, level.objectData[i].position, Quaternion.identity);
                NewObject.layer = 9;

                SpawnableObjectData eo = NewObject.AddComponent<SpawnableObjectData>();
                eo.data.position = NewObject.transform.position;
                eo.data.objectType = SpawnableObjectData.DataType.coin;
            }

            

            else if (level.objectData[i].objectType == SpawnableObjectData.DataType.startPos)
            {
                NewObject = Instantiate(startPoint, level.objectData[i].position, Quaternion.identity);
                NewObject.layer = 9; // set to Spawned Objects layer

                SpawnableObjectData eo = NewObject.AddComponent<SpawnableObjectData>();
                eo.data.position = NewObject.transform.position;
                eo.data.objectType = SpawnableObjectData.DataType.startPos;
            }

            else if (level.objectData[i].objectType == SpawnableObjectData.DataType.endPos)
            {
                NewObject = Instantiate(endPoint, level.objectData[i].position, Quaternion.identity);
                NewObject.layer = 9; // set to Spawned Objects layer
             
                SpawnableObjectData eo = NewObject.AddComponent<SpawnableObjectData>();
                eo.data.position = NewObject.transform.position;
                eo.data.objectType = SpawnableObjectData.DataType.endPos;
            }
        }
        loadLevelName.text = "";
        loadLevelName.DeactivateInputField();
        SaveLoadMessage.text = " Level Loading done";
    }

}
