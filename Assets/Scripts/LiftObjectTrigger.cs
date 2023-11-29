using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftObjectTrigger : MonoBehaviour
{
    private Transform gripPoint;

    private bool canCarry = false;
    private bool isCarried = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gripPoint = other.transform.GetChild(1);
            canCarry = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canCarry = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canCarry = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && canCarry)
        {
            if(!isCarried)
            {
                isCarried = true;
                transform.position = gripPoint.position;
                transform.rotation = gripPoint.rotation;
                transform.parent = gripPoint;
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<Collider>().isTrigger = true;
            }
            else
            {
                transform.parent = null;
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Collider>().isTrigger = false;
                isCarried = false;
            }
        }
    }
}
