using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public GameObject objectToToggle;
    public bool canToggle = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
        }
    }

    public void Toggle()
    {
        if(canToggle)
        {
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        }
    }
}
