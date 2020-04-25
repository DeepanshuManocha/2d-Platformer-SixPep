using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject player, startPoint;
    
    // Start is called before the first frame update
    void Start()
    {
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
