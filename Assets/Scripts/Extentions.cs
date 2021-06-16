using UnityEngine;

public static class Extentions
{
    public static bool IsInLayer(this LayerMask layerMask, int layerValue)
    {
        return layerMask == (layerMask | (1 << layerValue));
    }
}
