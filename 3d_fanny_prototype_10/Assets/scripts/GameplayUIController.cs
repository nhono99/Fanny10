using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour {
    public static GameplayUIController ins;
    [SerializeField]
    Text txtPoints;
    [SerializeField]
    Text txtRestart;
    [SerializeField]
    Text txtGameOverBest;
    [SerializeField]
    GameObject gameOverPanel;
    private void Awake()
    {
        ins = this;
    }
    private void Start()
    {
        txtPoints.text = "best " + (PlayerPrefs.GetFloat("best") / 3 ).ToString("0.0");
    }
    private void FixedUpdate()
    {
        if (GameController.ins.isGameplayActive)
        {
            txtPoints.text = (GameplayManager.ins.ClimbedHeight.currentHeight / 3).ToString("0.0");
        }
       
    }
    public void ShowGameOverBest()
    {
        float _best = GameplayManager.ins.ClimbedHeight.savedHighestHeight > GameplayManager.ins.ClimbedHeight.currentHighestHeight ? GameplayManager.ins.ClimbedHeight.savedHighestHeight : GameplayManager.ins.ClimbedHeight.currentHighestHeight;
        txtGameOverBest.gameObject.SetActive(true);
        txtGameOverBest.text = "best " + (_best / 3).ToString("0.0");
    }
    public void ShowGameOverPanel()
    {
        txtRestart.gameObject.SetActive(true);
        gameOverPanel.SetActive(true);
    }
}
