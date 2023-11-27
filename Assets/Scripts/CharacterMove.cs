using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float movementSpeed = 6f;

    float horizontal, vertical;
    Rigidbody body;
    Transform cameraTransform;
    public CameraMove cameraMove;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        cameraMove = cameraTransform.GetComponent<CameraMove>();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    

    private void FixedUpdate()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        Vector3 direction = forward * vertical + right * horizontal;

        Vector3 movement = transform.position + direction.normalized * Time.fixedDeltaTime * movementSpeed;

        body.MovePosition(movement);

        if (!cameraMove.firstPerson)
        {
            if(direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), 10 * Time.fixedDeltaTime);
            }
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(cameraTransform.forward);
        }
    }
}
