using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckLogic : MonoBehaviour
{
    public void StopPuck()
    {
        Rigidbody rigForPuck = gameObject.GetComponent<Rigidbody>();
        rigForPuck.velocity = Vector3.zero;
        rigForPuck.angularVelocity = Vector3.zero;
    }
}
