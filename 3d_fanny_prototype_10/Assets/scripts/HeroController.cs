using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroController : MonoBehaviour {

    private Hero model;
    private GearController gearController;
    [SerializeField]
    GameObject particleHit;
    [SerializeField]
    Material defaultMat, transparentMat;
    MeshRenderer meshRenderer;
    TrailRenderer trailRenderer;
    Color clrTempTransparent;
    Color clrOriginalTransparent;
    Collider collider;
    public Hero GetModel() {
        return model;
    }
    private void Awake()
    {
        model = new Hero();
        clrTempTransparent = transparentMat.color;
        clrOriginalTransparent = transparentMat.color;
        collider = GetComponent<Collider>();
    }
    void Start()
    {
       
        gearController = gearController ?? GetComponent<GearController>();
        meshRenderer = meshRenderer ?? GetComponent<MeshRenderer>();
        trailRenderer = trailRenderer ?? GetComponent<TrailRenderer>();

        meshRenderer.material = defaultMat;
        trailRenderer.material = defaultMat;
        meshRenderer.enabled = true;
        trailRenderer.enabled = true;

        clrTempTransparent = clrOriginalTransparent;
        transparentMat.color = clrOriginalTransparent;
        
    }

	public GearController GetGearController(){
		return gearController;
	}

    void OnCollisionEnter(Collision collision)
    {


        if (collision.collider.tag.Equals("Wall") || collision.collider.tag.Equals("Box"))
        {
            //GetComponent<Rigidbody>().velocity = Vector3.zero;
            //GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            TestController.ins.WallHit();
         
            particleHit.transform.position = transform.position;
            particleHit.SetActive(true);
            meshRenderer.material = transparentMat;
            trailRenderer.material = transparentMat;
            StartCoroutine(IEFadeOut());
           
        }
    }

    //for trigger types coliider
    void OnTriggerEnter2D(Collider2D collision)
    {

    }

    IEnumerator IEFadeOut()
    {
        while (clrTempTransparent.a > 0)
        {
            clrTempTransparent.a -= 0.2f;
            meshRenderer.material.color = clrTempTransparent;
            trailRenderer.material.color = clrTempTransparent;
            yield return new WaitForSeconds(0.02f);
        }
        meshRenderer.enabled = false;
        trailRenderer.enabled = false;
        gearController.GetRigidbody().isKinematic = true;
        PlayerController.ins.GetAudioController().PlayDead();
        GameController.ins.GameOver();
    }



}
