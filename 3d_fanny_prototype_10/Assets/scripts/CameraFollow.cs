using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    GameObject target;
    public float distance;
	
	// Update is called once per frame
	void Update () {
        transform.SetYPos(target.transform.position.y - distance);
	}
}
