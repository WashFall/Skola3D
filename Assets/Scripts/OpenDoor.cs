using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Interactable
{
    public bool autoClose = false;
    public bool xDoor = false;

    private bool canOpen = false;
    private Transform parent;
    private Quaternion startRotation;
    private Quaternion openRotation;

    public override void OnInteraction(RaycastHit hitInfo)
    {
        CancelInvoke(nameof(OpenTime));

        
        if (Vector3.Dot(hitInfo.point, transform.position) < 0)
        {
            openRotation = startRotation;
            openRotation.eulerAngles += new Vector3(0, -90, 0);
        }
        else
        {
            openRotation = startRotation;
            openRotation.eulerAngles += new Vector3(0, 90, 0);
        }

        canOpen = !canOpen;
        if(autoClose)
            Invoke(nameof(OpenTime), 2.5f);
    }

    private void Start()
    {
        parent = transform.parent.GetComponent<Transform>();

        startRotation = parent.transform.rotation;
        openRotation = startRotation;
        openRotation.eulerAngles += new Vector3(0, 90, 0);
    }

    private void Update()
    {
        if (canOpen)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    private void OpenTime()
    {
        canOpen = false;
    }

    private void Open()
    {
        parent.transform.rotation = Quaternion.Lerp(parent.transform.rotation, openRotation, 10 * Time.deltaTime);
    }

    private void Close()
    {
        parent.transform.rotation = Quaternion.Lerp(parent.transform.rotation, startRotation, 10 * Time.deltaTime);
    }

}
