using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsLimiter : MonoBehaviour
{

    [SerializeField] private int fps = 60;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = fps;
    }

    
    
}
