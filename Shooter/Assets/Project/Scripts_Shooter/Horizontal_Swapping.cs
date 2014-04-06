using UnityEngine;
using System.Collections;

public class Horizontal_Swapping : MonoBehaviour {

    public int Speed;
    int width;
    bool right;
    int Speed_x;

    void Start()
    {
        right = false;
    }

	void Update () {
    
        if (right)
        {
            Speed_x = Speed;
        } else
        {
            Speed_x = -Speed;
        }

        Vector3 position = Camera.main.WorldToScreenPoint(this.transform.position);

        if (position.x < 0)
        {
            right = true;
        }

        if (position.x > Screen.width)
        {
            right = false;
        }

        iTween.MoveAdd(this.gameObject, iTween.Hash("x", Speed_x, "time", 10f, "delay", 0, "onupdate", "myUpdateFunction", "EaseType", "linear", "looptype", iTween.LoopType.none));

	}
}
