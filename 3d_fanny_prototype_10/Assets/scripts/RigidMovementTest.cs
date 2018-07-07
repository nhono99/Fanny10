using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidMovementTest : MonoBehaviour {

    public float ms;
    Rigidbody rb;
    // Use this for initialization
    bool hit;
    Vector3 rightRot = new Vector3(-25f, 90f, 0);
    Vector3 left = new Vector3(10, -10, 14.5f);
    void Start () {
        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(rightRot);
    }
  

    // Update is called once per frame
    void FixedUpdate () {
        if (!hit)
            //rb.AddForce(
            //    (
            //    ((transform.position - left).normalized * )));
         
            rb.AddForce(transform.forward * ms * Time.fixedDeltaTime);

        
        print(rb.velocity.magnitude);
       
        
	}

    private void OnCollisionEnter(Collision collision)
    {
        hit = true;
        rb.velocity = Vector3.zero;
    }
}
