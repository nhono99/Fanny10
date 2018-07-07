using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererAnimate : MonoBehaviour {
    
   
    LineRenderer line;
    
    [SerializeField]
    Transform t1, t2;
   
    Vector3[] pos = new Vector3[2];
    private void Awake()
    {
         line = GetComponent<LineRenderer>();
    }

    private void OnEnable()
    {
        t1 = transform;
        t2 = GameObject.FindGameObjectWithTag("Player").transform;

      
    }

    private void OnDisable()
    {
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, Vector3.zero);
        pos[0] = Vector3.zero;
        pos[1] = Vector3.zero;
        t1 = null;
        t2 = null;
    }
 

    private void Update()
    {
        if(t1 != null && t2 != null)
        {
            pos[0] = t1.position;
            pos[1] = t2.position;
            line.SetPositions(pos);
        }
        
    }

   
}
