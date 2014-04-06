using UnityEngine;
using System.Collections;

public class Spawn_Bullet_E : MonoBehaviour {

    public GameObject Bullet;
    bool Timer;
    int Timer_int, Timer_Max;

	// Use this for initialization
	void Start () {
	
        Timer_Max = Random.Range(50, 200);
        Timer_int = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (Timer_int > Timer_Max)
        {
            Timer_Max = Random.Range(30, 200);
            Timer_int = 0;
            Instantiate(Bullet, this.transform.position, Quaternion.identity);
        }

        Timer_int++;
	}
}
