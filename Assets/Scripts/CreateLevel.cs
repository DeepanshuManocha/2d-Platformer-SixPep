using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine.UI;
public class CreateLevel : MonoBehaviour
{
    [SerializeField]private GameObject inputField;
    private string levelName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void StoreLevelName()
    {
        levelName= inputField.GetComponent<Text>().text;
    }

    public void AddNewScene()
    {
        StoreLevelName();
        Scene newScene = SceneManager.CreateScene(levelName);
        //var newScene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
        Debug.Log("NewScene created");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
