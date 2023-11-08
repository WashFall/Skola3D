using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    public GameObject selectedObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TrySelectObject();
        }

        if (Input.GetKeyDown(KeyCode.F) && selectedObject != null)
        {
            selectedObject.transform.localScale *= 1.1f;
        }
    }

    void TrySelectObject()
    {
        RaycastHit hitInfo = new RaycastHit();

        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

        if (hit)
        {
            selectedObject = hitInfo.transform.gameObject;
        }
        else
        {
            selectedObject = null;
        }
    }
}
