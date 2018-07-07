using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController ins;

    public bool isGameplayActive = false;

    private void Awake()
    {
        if(ins == null)
        {
            ins = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
     
    }
    private void OnEnable()
    {
        
    }

    public void StartPlaying()
    {
        isGameplayActive = true;
        PlayerController.ins.GetAudioController().PlayTap();
        PlayerController.ins.GetHeroController().GetGearController().SpawnHook(0);
    }

    public void GameOver()
    {
        isGameplayActive = false;
        GameplayUIController.ins.ShowGameOverPanel();
        GameplayUIController.ins.ShowGameOverBest();
        if(GameplayManager.ins.ClimbedHeight.savedHighestHeight < GameplayManager.ins.ClimbedHeight.currentHighestHeight)
        {
            PlayerPrefs.SetFloat("best", GameplayManager.ins.ClimbedHeight.currentHighestHeight);
        }
       

    }

    public void Restart()
    {
        SceneManager.LoadScene("main");
    }
}
