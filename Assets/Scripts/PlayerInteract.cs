using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private GameObject gripPoint;
    //private int layerMask = ~(1 << 2);

    private void Start()
    {
        gripPoint = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(transform.position, transform.forward, out hitInfo, 2f);
            //bool hit = Physics.SphereCast(transform.position, 1f, transform.forward, out hitInfo, 1f, layerMask);

            if(hit)
            {
                Interactable interactable;

                hitInfo.transform.TryGetComponent<Interactable>(out interactable);

                if(interactable != null)
                {
                    if(interactable.pickUp) interactable.OnInteraction(gripPoint, hitInfo);
                    else interactable.OnInteraction(hitInfo);
                }
                else
                {
                    Debug.Log("Not interactable");
                }
            }
        }
    }

    //static void DrawWireSphere(Vector3 center, float radius, Color color, float duration, int quality = 3)
    //{
    //    quality = Mathf.Clamp(quality, 1, 10);

    //    int segments = quality << 2;
    //    int subdivisions = quality << 3;
    //    int halfSegments = segments >> 1;
    //    float strideAngle = 360F / subdivisions;
    //    float segmentStride = 180F / segments;

    //    Vector3 first;
    //    Vector3 next;
    //    for (int i = 0; i < segments; i++)
    //    {
    //        first = (Vector3.forward * radius);
    //        first = Quaternion.AngleAxis(segmentStride * (i - halfSegments), Vector3.right) * first;

    //        for (int j = 0; j < subdivisions; j++)
    //        {
    //            next = Quaternion.AngleAxis(strideAngle, Vector3.up) * first;
    //            UnityEngine.Debug.DrawLine(first + center, next + center, color, duration);
    //            first = next;
    //        }
    //    }

    //    Vector3 axis;
    //    for (int i = 0; i < segments; i++)
    //    {
    //        first = (Vector3.forward * radius);
    //        first = Quaternion.AngleAxis(segmentStride * (i - halfSegments), Vector3.up) * first;
    //        axis = Quaternion.AngleAxis(90F, Vector3.up) * first;

    //        for (int j = 0; j < subdivisions; j++)
    //        {
    //            next = Quaternion.AngleAxis(strideAngle, axis) * first;
    //            UnityEngine.Debug.DrawLine(first + center, next + center, color, duration);
    //            first = next;
    //        }
    //    }
    //}
}
