using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreRotation : MonoBehaviour
{
    [SerializeField] private float rotationAmountx = 45;
    [SerializeField] private float rotationAmounty = 45;
    [SerializeField] private float rotationAmountz = 45;
    void Update()
    {
        transform.rotation = new Quaternion(0f,rotationAmountx, rotationAmounty, rotationAmountz);
    }
}
