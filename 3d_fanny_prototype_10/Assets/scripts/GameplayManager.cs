using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour {
    public static GameplayManager ins;
    [SerializeField]
    ClimbedHeight climbedHeight;

    void Awake()
    {
        ins = this;
        climbedHeight = new ClimbedHeight();
        climbedHeight.savedHighestHeight = PlayerPrefs.GetFloat("best");

    }
  
    public ClimbedHeight ClimbedHeight
    {
        get { return climbedHeight;  }
        set { climbedHeight = value; }
    }

  
  
    private void FixedUpdate()
    {
        if (climbedHeight.currentHeight < PlayerController.ins.transform.GetYPos()) {
            climbedHeight.currentHeight = PlayerController.ins.transform.GetYPos();
            if(climbedHeight.currentHeight > climbedHeight.savedHighestHeight)
            {
                climbedHeight.currentHighestHeight = climbedHeight.currentHeight;
            }
        }
      
        
    }
}
