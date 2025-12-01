using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyMarkerVisual : MonoBehaviour
{
    [SerializeField] private GameObject readyMarker;

    private bool isReady = false;
    public void ToggleMarker()
    {
        isReady = !isReady;
        readyMarker.SetActive(isReady);
    }

    public void Disable()
    {
        readyMarker.SetActive(false);
    }
}
