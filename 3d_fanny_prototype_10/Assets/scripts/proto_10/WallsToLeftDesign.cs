using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public sealed class WallsToLeftDesign{
    [SerializeField]
    List<Vector3> position;
    float finalXPosition = -5.5f;
    float startXPosition = 5.5f;
    float currentXPosition;
    float xDistance = 0.8f;

    int posIndex = 0;
    public WallsToLeftDesign(float startYPos, float zPos)
    {
        currentXPosition = startXPosition;

        position = new List<Vector3>(); 
        //spawn two wallToWall_2 to make an entrance
        position.Add(new Vector3(0f, startYPos, zPos));
        position.Add(new Vector3(2.03f, startYPos, zPos));
        position.Add(new Vector3(4.22f, startYPos, zPos));


        while (currentXPosition > finalXPosition)
        {
            position.Add(new Vector3(currentXPosition, startYPos, zPos));
            currentXPosition -= xDistance;
        }
        //spawn two wallToWall_2 to make an exit
        position.Add(new Vector3(-2.51f, startYPos, zPos));
        position.Add(new Vector3(-1.19f, startYPos, zPos));
        position.Add(new Vector3(0, startYPos, zPos));
    }

    public Vector3 GetPosition(ref int wallIndex)
    {
        if(posIndex < 3)
        {
            wallIndex = 1; //wallToWall_2
        }
        else if (posIndex >= position.Count - 3)
        {
            wallIndex = 0;
        }
        else
        {
            wallIndex = 2; //wallToWall_3
        }
        if(posIndex < position.Count)
            return position[posIndex++];

        return Vector3.zero;
    }
}
