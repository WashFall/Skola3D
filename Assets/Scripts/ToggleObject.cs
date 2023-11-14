using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public GameObject objectToToggle;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        objectToToggle.SetActive(!objectToToggle.activeSelf);
    }
}
