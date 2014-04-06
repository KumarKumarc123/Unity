using UnityEngine;
using System.Collections;

public class Asteroids_movement : MonoBehaviour {

    bool right;
    int Speed_x;
    public int Speed;
	
    void Start()
    {
        if (Camera.main.WorldToScreenPoint(this.transform.position).x < Screen.width / 2)
        {
            right = true;
        } else if (Camera.main.WorldToScreenPoint(this.transform.position).x > Screen.width)
        {
            right = false;
        }
    }


	void Update () {
	
        if (right)
        {
            Speed_x = Speed;
        } else
        {
            Speed_x = -Speed;
        }

        if (Vector3.Distance(this.transform.position, Camera.main.transform.position) > 13)
        {
            Destroy(this.gameObject);
        }

        iTween.MoveAdd(this.gameObject, iTween.Hash("x", Speed_x, "time", 10f, "delay", 0, "onupdate", "myUpdateFunction", "EaseType", "linear", "looptype", iTween.LoopType.none));
        Vector3 position = this.transform.position;
        position.z = 0;
        this.transform.position = position;
	}
}
