using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

//[Serializable]
public class DisplaLevels : MonoBehaviour
{
    public Text fileNameText;
    //public static readonly 
    // Start is called before the first frame update
    public void ShowSaveFiles()
    {
        string folder = Application.dataPath + "/SavedData";
        string[] Files = Directory.GetFiles(folder);
        List<string> fileName = new List<string>();
        for (int i = 0; i < Files.Length; i++)
            fileName.Add(Path.GetFileNameWithoutExtension(Files[i]));
        for (int i = 0; i < fileName.Count; i++)
            fileNameText.text+=" " + fileName[i];
    }
}
