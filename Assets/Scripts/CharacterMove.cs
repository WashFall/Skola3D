using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Transform cameraTransform;
    public float movementSpeed = 5f;

    Rigidbody body;
    float horizontal;
    float vertical;
    GameObject selectedObject;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            SelectObject();
        }

        if (Input.GetKeyDown(KeyCode.N) && selectedObject != null)
        {
            selectedObject.transform.localScale *= 1.1f;
        }
    }

    private void SelectObject()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        if (hit)
        {
            Debug.Log("Hit " + hitInfo.transform.gameObject.name);
            selectedObject = hitInfo.transform.gameObject;
        }
        else
        {
            Debug.Log("No hit");
            selectedObject = null;
        }
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

        if(direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
