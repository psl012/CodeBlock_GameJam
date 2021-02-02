using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLayerTarget
{
    public static bool LayerInLayerMask(int layer, LayerMask layerMask)
    {
        if (((1 << layer) & layerMask) != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
