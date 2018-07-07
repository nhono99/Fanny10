using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedPanelScript : MonoBehaviour {

    public void StartGame()
    {
        GameController.ins.StartPlaying();
    }
}
