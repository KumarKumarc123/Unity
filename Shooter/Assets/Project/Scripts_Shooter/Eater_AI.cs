using UnityEngine;
using System.Collections;

public class Eater_AI : MonoBehaviour {

    float target_x, target_y;
    bool Timer;
    int Timer_int, Timer_Max;
    int Speed_x, Speed_y;
    public int Speed;
    public GameObject Bullet;

    void Start () {
	
        Timer = true;
        Timer_int = 0;
        Timer_Max = 50;

        target_x = Camera.main.ScreenToWorldPoint(new Vector3(Screen.height/2, Screen.width/2, 0)).x;
        target_y = Camera.main.ScreenToWorldPoint(new Vector3(Screen.height/2, Screen.width/2, 0)).y;
	}
	
	void Update () {
	
        if (Timer_int > Timer_Max)
        {
            Timer_int = 0;
            Timer = true;
        }

        if (Timer)
        {
            Vector3 old_pos;
            Timer = false;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length > 1)
            {
               old_pos  = new Vector3(enemies[0].transform.position.x, enemies[0].transform.position.y, 0f);
            
            foreach (GameObject id in enemies)
            {
                float old_dist = Vector3.Distance(old_pos, this.transform.position);
                float new_dist = Vector3.Distance(id.transform.position, this.transform.position);

                if (new_dist < old_dist)
                {
                    old_pos = id.transform.position;
                    target_x = id.transform.position.x;
                    target_y = id.transform.position.y;
                }
            }
            }
        }

        Target(new Vector3(target_x, target_y, 0));

        iTween.MoveAdd(this.gameObject, iTween.Hash("x", Speed_x, "y", Speed_y, "time", 1f, "delay", 0, "onupdate", "myUpdateFunction", "EaseType", "linear", "looptype", iTween.LoopType.none ));

        Timer_int++;

	}

    void Target(Vector3 target)
    {
        Speed_x = 0;
        Speed_y = 0;

        if (target.x > this.transform.position.x)
        {
            Speed_x = Speed;
        } else if (target.x < this.transform.position.x)
        {
            Speed_x = -Speed;
        } 
            
        if (target.y > this.transform.position.y)
        {
            Speed_y = Speed;
        } else if (target.y < this.transform.position.y)
        {
            Speed_y = -Speed;
        }

    }

    void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "Enemy")
        {
            Destroy(colision.gameObject);
            Destroy(this.gameObject);
            Instantiate(Bullet, this.transform.position, Quaternion.identity);
        }

        if (colision.gameObject.tag == "Bullet")
        {
            GameObject GUI_Object = GameObject.Find("GUI");
            GUI_Object.GetComponent<Vital_Variables>().Score(5);
            Destroy(colision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
