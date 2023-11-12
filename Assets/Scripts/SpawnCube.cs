using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    public GameObject cubePrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, 1, transform.position.z) + transform.forward;
            SpawnCubeObject(spawnPosition, transform.rotation);
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit = new RaycastHit();

            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity);

            Vector3 spawnPosition = hit.point + new Vector3(0, 1, 0);
            Transform parent = hit.transform;

            SpawnCubeObject(spawnPosition, Quaternion.identity, parent);
        }
    }

    public void SpawnCubeObject(Vector3 position, Quaternion rotation, Transform parent = null)
    {
        if(parent != null)
        {
            GameObject newCube = Instantiate(cubePrefab, position, rotation);
            newCube.transform.parent = parent;
        }
        else
        {
            Instantiate(cubePrefab, position, rotation);
            Debug.Log("Hej");
        }
    }
}
