using UnityEngine;
using System.Collections;

public class Bullet_Direction : MonoBehaviour {

    public float Speed_X, Speed_Y;
	
	// Update is called once per frame
	void Update () {
	
        iTween.MoveAdd(this.gameObject, iTween.Hash("x", Speed_X, "y", Speed_Y, "time", 10f, "delay", 0, "onupdate", "myUpdateFunction", "EaseType", "linear", "looptype", iTween.LoopType.none));

        if (Vector3.Distance(this.transform.position, Camera.main.transform.position) > 15)
        {
            Destroy(this.gameObject);
        }

	}
}
