using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableHook : MonoBehaviour {
	
	bool collided = false;
    public delegate void collidePos(Vector3 pos);
    public collidePos OnCollidePos;
    public delegate void collideDirection();
    public collideDirection OnCollideDirection;
   
    Rigidbody rb;

    float speed;
    float constantSpeed = 1f;
    Collider col;
    GameObject wallHit;
    const float LIFE_TIME = 2f;
    private void Awake()
    {
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        speed = GearController.ins.GetModel().cableSpeed;
        Invoke("Hide", LIFE_TIME);
    }
    void FixedUpdate () {
		if(!collided)
        {
            rb.AddForce(transform.forward * speed * Time.fixedDeltaTime);
            rb.velocity = constantSpeed * (rb.velocity.normalized);
           
        }
        else
        {
            //if wall hit is deactivated and this hook is still active
            if(wallHit != null)
            {
                if (!wallHit.activeInHierarchy)
                {
                    gameObject.SetActive(false);
                }
            }
        }
        //transform.Translate (Vector2.right * GearController.ins.GetModel().cableSpeed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision){
       
		if (collision.collider.tag.Equals("Wall") || collision.collider.tag.Equals("End")) {
			collided = true;

         
            if (OnCollideDirection != null)
            {
                OnCollideDirection();
            }
            if(OnCollidePos != null)
            {
                OnCollidePos(transform.position);
            }
            rb.velocity = Vector3.zero;
            col.enabled = false;
            //transform.SetParent(collision.transform.parent);
            Invoke("Disable", 0.5f);
            wallHit = collision.gameObject;
            wallHit.GetComponent<WallChildController>().Disable(3f);

            HookParticlePoolerController.ins.Spawn(transform.position);
         
        }
	}

	void OnEnable(){
        col.enabled = true;
		collided = false;
	}

    private void Disable()
    {
        wallHit = null;
        gameObject.SetActive(false);
        CancelInvoke("Hide");
    }

    private void Hide()
    {
        if (!collided)
        {
            wallHit = null;
            gameObject.SetActive(false);
        }
       
    }

}
