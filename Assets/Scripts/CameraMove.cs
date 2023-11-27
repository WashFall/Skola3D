using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target, fpsCamera;
    public float followDistance = 8f;
    public float cameraSpeed = 3f;
    public bool firstPerson = false;

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        fpsCamera = target.GetChild(2);

        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            firstPerson = !firstPerson;
            target.GetChild(0).gameObject.SetActive(!firstPerson);
        }

        if(Input.mouseScrollDelta.y != 0)
        {
            followDistance -= Input.mouseScrollDelta.y;
        }
    }

    private void LateUpdate()
    {
        float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * cameraSpeed;
        float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * cameraSpeed;

        Vector3 desiredRotation = new Vector3(newRotationY, newRotationX, 0f);
        transform.localEulerAngles = desiredRotation;

        if (!firstPerson)
        {
            Vector3 desiredPosition = target.position - transform.forward * followDistance;
            transform.position = desiredPosition;
        }
        else
        {
            //transform.position = Vector3.Lerp(transform.position, fpsCamera.position, 20 * Time.deltaTime);
            transform.position = fpsCamera.position;
        }

    }
}
