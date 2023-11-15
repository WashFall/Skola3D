using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject textPanel;

    // This method is called when PlayerInteract tries to interact with this object
    public virtual void OnInteraction()
    {
        textPanel.SetActive(true);
    }
}
