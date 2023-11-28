using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Klassen LiftObject ärver av klassen Interactable.
public class LiftObject : Interactable
{
    private bool isCarried = false;

    private void Start()
    {
        pickUp = true; // pickUp är en bool i klassen Interactable.
    }

    // Detta är en override av metoden OnInteraction som finns i klassen Interactable.
    public override void OnInteraction(GameObject gripPoint, RaycastHit hitInfo)
    {
        if (!isCarried)
        {
            isCarried = true;
            transform.position = gripPoint.transform.position;
            transform.rotation = gripPoint.transform.rotation;
            transform.parent = gripPoint.transform;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().isTrigger = true;
        }
        else
        {
            transform.parent = null;
            GetComponent<Rigidbody>().isKinematic = false;
            isCarried = false;
            GetComponent<Collider>().isTrigger = false;
        }
    }
}
