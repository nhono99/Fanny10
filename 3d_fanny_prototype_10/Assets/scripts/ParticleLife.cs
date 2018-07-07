using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLife : MonoBehaviour {

    public float life;

	void OnEnable() {
        Invoke("Disable", life);
	}
	
	void Disable()
    {
        gameObject.SetActive(false);
    }
}
