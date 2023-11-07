using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    GameObject selectedObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TrySelectObject();
        }

        if (Input.GetKeyDown(KeyCode.N) && selectedObject != null)
        {
            selectedObject.transform.localScale *= 1.1f;
        }
    }
    private void TrySelectObject()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        if (hit)
        {
            Debug.Log("Hit " + hitInfo.transform.gameObject.name);
            selectedObject = hitInfo.transform.gameObject;
        }
        else
        {
            Debug.Log("No hit");
            selectedObject = null;
        }
    }
}
