using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEffectAtPoint : MonoBehaviour
{
    [SerializeField] private ParticleSystem effect;
    void OnEnable()
    {
        if(effect == null) effect = gameObject.GetComponent<ParticleSystem>();
    }

    public void Here(Vector3 position)
    {
        transform.position = position;
        effect.Play();
    }
}