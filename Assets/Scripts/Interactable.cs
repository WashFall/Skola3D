using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool pickUp = false;

    // This method is called when PlayerInteract tries to interact with this object
    public virtual void OnInteraction(RaycastHit hitInfo)
    {
        Debug.Log("Normal Interact");
    }

    public virtual void OnInteraction(GameObject player, RaycastHit hitInfo)
    {
        Debug.Log("Interact With Player Object");
    }
}
