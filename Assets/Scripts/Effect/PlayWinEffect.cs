using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWinEffect : MonoBehaviour
{
    private List<GameObject> effects = new();
    
    void Awake()
    {
        GetAllChildren();
    }

    private void GetAllChildren()
    {
        foreach(Transform child in transform)
        {
            effects.Add(child.gameObject);
        }
    }

    public void Play()
    {
        foreach(GameObject effect in effects)
        {
            effect.GetComponent<ParticleSystem>().Play();
        }
    }
}
