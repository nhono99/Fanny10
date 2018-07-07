using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float speed;
    public enum DIRECTION { up, down, left, right};
    public DIRECTION dir;
 

	// Update is called once per frame
	void FixedUpdate () {
        if (dir == DIRECTION.down) {
            transform.Translate(Vector2.down * speed);
            //transform.SetYPos(transform.GetYPos() - speed);
        }
        else if (dir == DIRECTION.up)
        {
            transform.Translate(Vector2.up * speed);
        }
        else if (dir == DIRECTION.left)
        {
            transform.Translate(Vector2.left * speed);
        }
        else if (dir == DIRECTION.right)
        {
            transform.Translate(Vector2.right * speed);
        }
    }
}
