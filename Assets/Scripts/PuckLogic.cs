using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuckLogic : MonoBehaviour
{
    public UnityEvent SFXEventPuckPLayer = new(); 
    public UnityEvent SFXEventPuckWall = new(); 
    public void StopPuck()
    {
        Rigidbody rigForPuck = gameObject.GetComponent<Rigidbody>();
        rigForPuck.velocity = Vector3.zero;
        rigForPuck.angularVelocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ArenaObj"))
        {
            SFXEventPuckWall.Invoke();
        }
        else
        {
            SFXEventPuckPLayer.Invoke();
        }
        
    }
}
