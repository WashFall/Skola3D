using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Interactable
{
    private bool canOpen = false;
    private Transform parent;
    private Quaternion startRotation;
    private Quaternion openRotation;

    public override void OnInteraction()
    {
        canOpen = true;
    }

    private void Start()
    {
        parent = transform.parent.GetComponent<Transform>();

        startRotation = parent.transform.rotation;
        openRotation = startRotation;
        openRotation.eulerAngles = new Vector3(openRotation.x, openRotation.y + 90, openRotation.z);
    }

    private void Update()
    {
        if (canOpen)
        {
            parent.transform.rotation = Quaternion.Lerp(parent.transform.rotation, openRotation, 10 * Time.deltaTime);
        }
    }
}
