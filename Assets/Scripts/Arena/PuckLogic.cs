using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuckLogic : MonoBehaviour
{
    public void StopPuck()
    {
        Rigidbody rigForPuck = gameObject.GetComponent<Rigidbody>();
        rigForPuck.velocity = Vector3.zero;
        rigForPuck.angularVelocity = Vector3.zero;
    }
}
