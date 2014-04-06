using UnityEngine;
using System.Collections;

public class Allied_Plane : MonoBehaviour {

    float target_x, target_y;
    bool Timer;
    int Timer_int, Timer_Max;
    int Speed_x, Speed_y;
    public int Speed;
    public GameObject Bullet;
    public AudioClip Dead_Sound;

    int Timer_Shoot, Timer_Max_Shoot;

    
    void Start () {
        
        Timer = true;
        Timer_int = 50;
        Timer_Max = 10;

        Timer_Max_Shoot = Random.Range(20, 100);
        Timer_Shoot = 0;
        
        target_x = this.transform.position.x;
        target_y = this.transform.position.y;
    }

    void Update () {
        
        if (Timer_int > Timer_Max)
        {
            Timer_int = 0;
            Timer = true;
        }

        if (Timer_Shoot > Timer_Max_Shoot)
        {
            Timer_Shoot = 0;
            Timer_Max_Shoot = Random.Range(20, 100);

            Instantiate(Bullet, this.transform.position, Quaternion.identity);
        }

        if (Timer)
        {
            Vector3 old_pos;
            Timer = false;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            
            if (enemies.Length > 1)
            {
                old_pos = new Vector3(enemies [0].transform.position.x, enemies [0].transform.position.y, 0f);
                
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

        
        iTween.MoveAdd(this.gameObject, iTween.Hash("x", Speed_x, "y", Speed_y, "time", 1f, "delay", 0, "onupdate", "myUpdateFunction", "EaseType", "linear", "looptype", iTween.LoopType.none ));

        Target(new Vector3(target_x, target_y, 0));

        Timer_int++;
        Timer_Shoot++;

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
        if (colision.gameObject.tag == "Bullet_Enemy")
        {
            AudioSource.PlayClipAtPoint(Dead_Sound, this.transform.position);
            Destroy(this.gameObject);
            Destroy(colision.gameObject);
        }
    }

}