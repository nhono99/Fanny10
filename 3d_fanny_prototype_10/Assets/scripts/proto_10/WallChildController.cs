using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChildController : MonoBehaviour {


    public void Disable(float time)
    {
        Invoke("DisableWall", time);
    }

    void DisableWall()
    {
        gameObject.SetActive(false);
    }
}
