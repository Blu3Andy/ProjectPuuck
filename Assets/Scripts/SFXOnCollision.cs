using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SFXOnCollision : MonoBehaviour
{

    public UnityEvent SFXEventObject = new();
    public LayerMask layerMaskForColl;

    void OnCollisionEnter(Collision collision)
    {
        if(Helper.IsInLayerMask(collision.gameObject, layerMaskForColl))
        {
            SFXEventObject.Invoke();
        }
    }
}

