using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalSignLogic : MonoBehaviour
{
    private int count = 0;
    void Start()
    {
        gameObject.GetComponent<Text>().text = "0";
    }
    
    public void CountUp()
    {
        count++;
        gameObject.GetComponent<Text>().text = count.ToString();
    }
}
