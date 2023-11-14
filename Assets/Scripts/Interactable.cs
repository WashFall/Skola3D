using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is for GameObjects that the player
 * will interact with.
 */


public class Interactable : MonoBehaviour
{
    public GameObject textPanel;


    // This method is called when PlayerInteract tries to interact with this object
    public void OnInteraction()
    {
        textPanel.SetActive(true);
    }
}
