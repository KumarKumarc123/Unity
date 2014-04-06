using UnityEngine;
using System.Collections;

public class Enemy_Bullet_Movement : MonoBehaviour {

    Vector3 direction;
 
    public float Speed;

	// Use this for initialization
	void Start () {
	
        Vector3 player_pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        direction = (player_pos - transform.position).normalized;

	}
	
	// Update is called once per frame
	void Update () {
	
        if (Vector3.Distance(this.transform.position, Camera.main.transform.position) > 13)
        {
            Destroy(this.gameObject);
        } 

        Vector3 new_dir = direction * Speed;

        iTween.MoveAdd(this.gameObject, iTween.Hash("x", new_dir.x, "y", new_dir.y, "time", 1f, "delay", 0, "onupdate", "myUpdateFunction", "EaseType", "linear", "looptype", iTween.LoopType.none ));
	}
}
