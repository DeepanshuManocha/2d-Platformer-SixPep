using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnObjects : MonoBehaviour
{
    public static GameObject spawnableObject=null;
    private GameObject spawnedObject=null;
    public bool startPointSpawned, endPointSpawned;


    // Start is called before the first frame update
    void Start()
    {
        startPointSpawned = false;
        endPointSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnObject();
        DestroyObjects();

    }

    void SpawnObject()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (spawnableObject == null)
        {
            return;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray, Camera.main.transform.forward);

                if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("Coin") || hit.collider.CompareTag("startPoint") || hit.collider.CompareTag("endPoint"))
                    return;
                else if (hit)
                {
                    if(spawnableObject.CompareTag("Ground") || spawnableObject.CompareTag("Coin"))
                        spawnedObject = Instantiate(spawnableObject, hit.point, Quaternion.identity) as GameObject;
                    if(spawnableObject.CompareTag("startPoint") && !startPointSpawned)
                        spawnedObject = Instantiate(spawnableObject, hit.point, Quaternion.identity) as GameObject;
                    if (spawnableObject.CompareTag("endPoint") && !endPointSpawned)
                        spawnedObject = Instantiate(spawnableObject, hit.point, Quaternion.identity) as GameObject;
                   
                    if (spawnedObject.CompareTag("startPoint"))
                        startPointSpawned = true;
                    if (spawnedObject.CompareTag("endPoint"))
                        endPointSpawned = true;
                    
                }
            }
        }
    }

    void DestroyObjects()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Camera.main.transform.forward);

            if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("Coin") )
                Destroy(hit.collider.gameObject);
           
            else if(hit.collider.CompareTag("endPoint"))
            {
                Destroy(hit.collider.gameObject);
                endPointSpawned = false;
            }

            else if (hit.collider.CompareTag("startPoint"))
            {
                Destroy(hit.collider.gameObject);
                startPointSpawned = false;
            }
            else
                return;

        }
    }

}
