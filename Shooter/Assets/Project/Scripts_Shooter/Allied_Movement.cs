using UnityEngine;
using System.Collections;

public class Allied_Movement : MonoBehaviour {

    public int Speed;
    float Speed_x, Speed_y;
    public float offset;
    public GameObject bullet;
    int Timer;
    int Timer_Max;
    public AudioClip dead;

    void Start()
    {
        Timer = 0;
        Timer_Max = Random.Range(50, 150);
    }

	void Update () {
	
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        Target(Player.transform.position);

        iTween.MoveAdd(this.gameObject, iTween.Hash("x", Speed_x, "y", Speed_y, "time", 1f, "delay", 0, "onupdate", "myUpdateFunction", "EaseType", "linear", "looptype", iTween.LoopType.none ));

        if (Timer > Timer_Max)
        {
            Timer = 0;
            Timer_Max = Random.Range(50, 150);

            Instantiate(bullet, this.transform.position, Quaternion.identity);
        }

        Timer++;
	}

    void Target(Vector3 target)
    {
        Speed_x = 0;
        Speed_y = 0;
        
        if (target.x > this.transform.position.x + offset)
        {
            Speed_x = Speed;
        } else if (target.x < this.transform.position.x - offset)
        {
            Speed_x = -Speed;
        } 
        
        if (target.y > this.transform.position.y + offset)
        {
            Speed_y = Speed;
        } else if (target.y < this.transform.position.y - offset)
        {
            Speed_y = -Speed;
        }
        
    }

    void OnCollisionEnter2D (Collision2D colision)
    {
        if (colision.gameObject.tag == "Enemy_Bullet")
        {
            AudioSource.PlayClipAtPoint(dead, this.transform.position);
            Destroy(this.gameObject);
            Destroy(colision.gameObject);

        }
    }
}
