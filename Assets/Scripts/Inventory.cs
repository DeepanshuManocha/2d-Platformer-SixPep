using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //SerializeField]private GameObject[] spawnableObjects;
    
    

    public void selectPlatform( GameObject go)
    {
        SpawnObjects.spawnObject = go;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
