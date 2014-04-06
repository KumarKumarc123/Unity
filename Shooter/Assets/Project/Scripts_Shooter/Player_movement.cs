using UnityEngine;
using System.Collections;

public class Player_movement : MonoBehaviour {

	public float Speed;
	float Speed_X, Speed_Y;

	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey(KeyCode.LeftArrow))
        {
            Speed_X = -Speed;
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            Speed_X = Speed;
        } else
        {
            Speed_X = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Speed_Y = Speed;
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            Speed_Y = -Speed;
        } else
        {
            Speed_Y = 0;
        }

        iTween.MoveAdd(this.gameObject, new Vector3(Speed_X, Speed_Y, 0), 1f);

	}
}
