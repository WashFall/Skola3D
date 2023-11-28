using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftObjectTrigger : MonoBehaviour
{
    public Transform gripPoint;

    private bool canCarry = false;
    private bool isCarried = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gripPoint = other.transform.GetChild(1);
            canCarry = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canCarry = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canCarry = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && canCarry)
        {
            if (!isCarried)
            {
                isCarried = true;
                transform.position = gripPoint.position;
                transform.rotation = gripPoint.rotation;
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
}
