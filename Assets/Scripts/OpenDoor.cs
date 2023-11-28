using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Klassen OpenDoor �rver av klassen Interactable.
public class OpenDoor : Interactable
{
    public bool autoClose = false;

    private bool canOpen = false;
    private Transform parent;
    private Quaternion startRotation;
    private Quaternion openRotation;

    // Detta �r en override av metoden OnInteraction som �rvs fr�n klassen Interactable.
    public override void OnInteraction(RaycastHit hitInfo)
    {
        CancelInvoke(nameof(OpenTime)); // Om d�rren �r p�v�g att st�ngas, avbryt den.
        
        // Jag kollar i vilken riktning fr�n d�rren min Raycast tr�ffar, och avg�r sedan vilket h�ll den ska �ppnas �t.
        Vector3 direction = (transform.position - hitInfo.point) / Vector3.Distance(transform.position, hitInfo.point);
        float angle = Vector3.Angle(direction, transform.right);
        
        if (angle < 90)
        {
            openRotation = startRotation;
            float num1 = 0.95f;
            int num = (int)num1;
            print(num);
            openRotation.eulerAngles += new Vector3(0, -90, 0);
        }
        else
        {
            openRotation = startRotation;
            openRotation.eulerAngles += new Vector3(0, 90, 0);
        }

        canOpen = !canOpen;

        // Om vi vill att d�rren ska st�ngas automatiskt s� kallar vi p� den metoden efter 2,5 sekunder.
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
