using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject saveLevelMenu;
    public void LoadSaveLevelMenu()
    {
        saveLevelMenu.SetActive(true);
    }
    
    public void CloseSaveLevelMenu()
    {
        saveLevelMenu.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void CreateLevelScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevelScene()
    {
        SceneManager.LoadScene(1);
    }

}
