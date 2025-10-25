using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
     public static bool IsInLayerMask(GameObject obj, LayerMask mask)
    {
        return (mask == (mask | (1 << obj.layer)));
    }
}
