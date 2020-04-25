using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnObjects : MonoBehaviour
{
    public static GameObject spawnableObject=null;
    private GameObject spawnedObject=null;

    // Start is called before the first frame update
    void Start()
    {
        
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
                    spawnedObject=Instantiate(spawnableObject, hit.point, Quaternion.identity) as GameObject;
                }

            }
        }
    }

    void DestroyObjects()
    {
        /*if (Input.GetMouseButtonDown(1))
        {
            if (spawnedObject == null)
                return;
            else if (spawnedObject.CompareTag("Ground") ||spawnedObject.CompareTag("Coin") || spawnedObject.CompareTag("startPoint") || spawnedObject.CompareTag("endPoint"))
                Destroy(spawnedObject);
           
        }
        */

        if (Input.GetMouseButtonDown(1))
        {
            var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Camera.main.transform.forward);

            if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("Coin") || hit.collider.CompareTag("startPoint") || hit.collider.CompareTag("endPoint"))
                Destroy(hit.collider.gameObject);
                
            else 
            {
                 return;
            }

        }
    }

}
