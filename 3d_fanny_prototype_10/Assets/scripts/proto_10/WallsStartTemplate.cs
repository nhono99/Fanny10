using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsStartTemplate : MonoBehaviour {

    [SerializeField]
    GameObject wall;
    [SerializeField]
    float yDistance;
    const float zPos = 15.3f;
    float startYpos = 17f;
    [SerializeField]
    float[] xPos;
    int xPosIndex = 0;
    void Start () {
        for (int i=0; i<12; i++) {
            Spawn();
        }
	}

    void Spawn() {
        Instantiate(wall, new Vector3(xPos[xPosIndex++], startYpos,zPos), Quaternion.identity);
        startYpos -= yDistance;
      
    }
	
}
