using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    // One Way Script
    [SerializeField] private Transform spawn;
    [SerializeField] private float knochBackRadius = 5f;
    [SerializeField] private float knochBackForce = 50f; 

    public void Execute(GameObject player)
    {
        player.transform.position = spawn.position;

        //player.GetComponent<PlayerController>().RagdollEvent();

        player.GetComponent<Rigidbody>().AddExplosionForce(knochBackForce, transform.position + new Vector3(-4, 0, 0), knochBackRadius);
    }

    public void makeBoom()
    {
        var surroundingObjects = Physics.OverlapSphere(spawn.position , knochBackRadius);
        print(surroundingObjects);

        foreach(var obj in surroundingObjects)
        {

            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if(rb == null) continue;

            
        }
    }
}
