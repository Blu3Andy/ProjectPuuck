using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTransition : MonoBehaviour
{
    public static ScreenTransition instance;

    private List<GameObject> animations = new();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        GetAllChildren();        
    }

    private void GetAllChildren()
    {
        foreach(Transform child in transform)
        {
            animations.Add(child.gameObject);
        }
    }

    public void Play()
    {
        int random = Random.Range(0, animations.Count-1);

        //The Gameobjects have only one animation, so its enough to just toggle them on and off to play the animation
        animations[random].SetActive(false);
        animations[random].SetActive(true);
    }

}
