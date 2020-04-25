using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnObjects : MonoBehaviour
{
    public static GameObject spawnObject=null;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnObject();
    }

    void SpawnObject()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (spawnObject == null)
        {
            return;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray, Camera.main.transform.forward);

                if (hit.collider.CompareTag("Ground"))
                    return;
                else if (hit)
                {
                    Instantiate(spawnObject, hit.point, Quaternion.identity);
                }

            }
        }
    }
   
}
