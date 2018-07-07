using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
    public static PlayerController ins;

	[SerializeField]
	HeroController hero;
    [SerializeField]
    PlayerAudioController audioController;
   
    public PlayerAudioController GetAudioController()
    {
        return audioController;
    }
    public HeroController GetHeroController() {
        return hero;
    }

    void Awake()
    {
        ins = this;
    }

  
    void Update()
	{
        if (Input.GetMouseButtonDown(0) && GameController.ins.isGameplayActive){
            hero.GetGearController().SpawnHook(0);
            audioController.PlayTap();
        }
    }

   
   

  

}
