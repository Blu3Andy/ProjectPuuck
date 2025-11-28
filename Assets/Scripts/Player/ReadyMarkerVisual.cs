using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyMarkerVisual : MonoBehaviour
{
    [SerializeField] private GameObject readyMarker;
    private bool isReady = false;
    public void ToggleMarker()
    {
        print("kek is toggled");
        isReady = !isReady;
        readyMarker.SetActive(isReady);
    }
}
