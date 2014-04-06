using UnityEngine;
using System.Collections;

public class Enemy_Move : MonoBehaviour {

    public enum Mood 
    {
        Aggressive, Crazy, Normal, 
    }

    public Mood Behaviour;
    public float offset;
    public float offset_crazy;
    int My_mood;
    public float My_Speed;
    float Speed_x, Speed_y;
    Vector3 Start_pos;
    int target_x, target_y;
    bool vertical;
    bool Timer_crazy;
    int Timer_Max;
    int Timer_crazy_int;

	void Start () {
        vertical = true;
        Timer_crazy = true;
        Timer_Max = Random.Range(20, 200);

        target_x = Random.Range(0, Screen.width);
        target_y = Random.Range(0, Screen.height);

	}
	
	// Update is called once per frame
	void Update () {
	
        switch (Behaviour)
        {
            case Mood.Aggressive: Aggresive();
                break;
            case Mood.Crazy: Crazy();
                break;
            case Mood.Normal: Normal();
                break;
        }

        Vector3 position = Camera.main.WorldToScreenPoint(this.transform.position);

        if (position.x < 0)
        {
            Speed_x = My_Speed;
        }
        if (position.x > Screen.width)
        {
            Speed_x = -My_Speed;
        }
        if (position.y < 0)
        {
            Speed_y = My_Speed;
        }
        if (position.y > Screen.height)
        {
            Speed_y = -My_Speed;
        }

        iTween.MoveAdd(this.gameObject, iTween.Hash("x", Speed_x, "y", Speed_y, "time", 1f, "delay", 0, "onupdate", "myUpdateFunction", "EaseType", "linear", "looptype", iTween.LoopType.none ));

        if (Timer_crazy_int > Timer_Max)
        {
            Timer_crazy_int = 0;
            Timer_crazy = true;
        }

        Timer_crazy_int++;
	}

    void Normal()
    {
        if (vertical == true)
        {
            Speed_y = -My_Speed;
        } else
        {
            Speed_y = My_Speed;
        }

        Vector3 position = Camera.main.WorldToScreenPoint(this.transform.position);

        if (position.y < 0)
        {
            ChangeVertical();
        }

        if (position.y > Screen.height)
        {
            ChangeVertical();
        }

    }

    void ChangeVertical()
    {
        if (vertical == true)
        {
            vertical = false;
        } else
        {
            vertical = true;
        }

    }

    void Crazy()
    {
        Vector3 target_pos = new Vector3(target_x, target_y, 0);

        if (Timer_crazy == true)
            {
                target_x = Random.Range(0, Screen.width);
                target_y = Random.Range(0, Screen.height);
                Timer_crazy = false;
                Timer_Max = Random.Range(100, 200);
            }
        
        A_Star(Camera.main.ScreenToWorldPoint(target_pos));
        
     }


    void Aggresive()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        A_Star(Player.transform.position);
    }

    void A_Star(Vector3 Target)
    {
        if (Vector3.Distance(Target, this.transform.position) > offset)
        {
            if (Target.x > this.transform.position.x)
            {
                Speed_x = My_Speed;
            } else if (Target.x < this.transform.position.x)
            {
                Speed_x = -My_Speed;
            } else
            {
                Speed_x = 0;
            }
            
            if (Target.y > this.transform.position.y)
            {
                Speed_y = My_Speed;
            } else if (Target.y < this.transform.position.y)
            {
                Speed_y = -My_Speed;
            } else
            {
                Speed_y = 0;
            }
        }
    }

}
