using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

    [SerializeField]
    private float minXPos, maxXPos;
    [SerializeField]
    private float xPosDistance;
    [SerializeField]
    
    public float GetMinXPosition()
    {
        return minXPos;
    }
    public float GetMaxXPosition()
    {
        return maxXPos;
    }
    public float GetXPositionDistance() {
        return xPosDistance;
    }

}
