using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestController : MonoBehaviour {
    public static TestController ins;
    public bool enableTest;
    [SerializeField]
    Text txtWallHit;
    int wallHit;
    private void Start()
    {
        ins = this;
        if (!enableTest)
        {
            txtWallHit.text = "";
        }
    }

    public void WallHit() {
        if (enableTest)
        {
            txtWallHit.text = "" + wallHit++.ToString();
        }
      
    }

    private void Update()
    {
        if (enableTest)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                wallHit = 0;
                txtWallHit.text = "0";
            }
        }
      
    }
}
