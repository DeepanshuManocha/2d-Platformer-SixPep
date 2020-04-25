using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]private GameObject player;
    private GameObject startPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        startPoint = GameObject.FindGameObjectWithTag("startPoint");
        PlayerSpawn();
    }
    private void PlayerSpawn()
    {
        player = Instantiate(player, startPoint.transform.position, Quaternion.identity) as GameObject;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
