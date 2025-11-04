using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsBehindSomething : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private LayerMask layer;

    [SerializeField] private float sightRange = 1000f;

    [SerializeField] private UnityEvent isHidden;
    [SerializeField] private UnityEvent isNotHidden;

    private bool hidden = false;

    private void Awake()
    {
        cam = Camera.main.transform;
    }

     void Update()
    {
        Vector3 rayCastDirection = (cam.transform.position - transform.position);
        RaycastHit hit;
        Ray ray = new(transform.position, rayCastDirection);

        if (Physics.Raycast(ray, out hit, sightRange, layer))
        {
            // Gizmos.DrawLine(transform.position, cam.transform.position - transform.position);
            if (!hidden) isHidden.Invoke();
            hidden = !hidden;
        }
        else
        {
            // Gizmos.DrawLine(transform.position, cam.transform.position - transform.position);
            if (hidden) isNotHidden.Invoke();
            hidden = !hidden;
        }
    }
}
