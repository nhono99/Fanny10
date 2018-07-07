using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GearController : MonoBehaviour {
	public static GearController ins;
	private GearModel model;
	
	[SerializeField]
	GameObject hook;
    [SerializeField]
    ObjectPooler pooler;
    public int side = 0;
    [SerializeField]
    Vector3 right, left;
    [SerializeField]
    Vector3 hookRotationRight, hookRotationLeft;
    Rigidbody rb;

    Vector3 tempLeft, tempRight;

    public GearModel GetModel()
    {
        return model;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ins = this;
        //serialize this
        //250 pullspeed for addforce
        //10 pullspeed for velo
        model = new GearModel(0.01f, 500f, 7f);

        rb.isKinematic = true;
       // pooler.Preload(Instantiate(hook, transform.position, Quaternion.Euler(Vector3.zero)) as GameObject, 4);
        pooler.Preload(hook, 4);
        tempLeft = left;
        tempRight = right;
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    public void SpawnHook(float z)
    {
    }

    Vector3 GeHooktRotation()
    {
    }

    void Pull(Vector3 pos)
    {
      
    }

    void Pull()
    {
       
    }


	
		
}
