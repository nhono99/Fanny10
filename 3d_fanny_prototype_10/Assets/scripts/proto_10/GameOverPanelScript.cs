using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanelScript : MonoBehaviour {

	 public void Restart()
    {
        GameController.ins.Restart();
    }
}
