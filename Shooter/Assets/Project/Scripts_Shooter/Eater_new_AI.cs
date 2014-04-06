using UnityEngine;
using System.Collections;

public class Eater_new_AI : MonoBehaviour {

    public int Speed;
    int Speed_x, Speed_y;
    bool right, up;
    int HP;
    public AudioClip dead;

	// Use this for initialization
	void Start () {
        right = true;
        up = false;

        HP = 2;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
        
        if (pos.x < 0)
        {
            right = true;
        }
        if (pos.x > Screen.width)
        {
            right = false;
        }
        
        if (pos.y < 0)
        {
            up = true;
        }
        if (pos.y > Screen.height)
        {
            up = false;
        }

        if (right)
        {
            Speed_x = Speed;
        } else
        {
            Speed_x = -Speed;
        }

        if (up)
        {
            Speed_y = Speed;
        } else
        {
            Speed_y = -Speed;
        }

        iTween.MoveAdd(this.gameObject, iTween.Hash("x", Speed_x, "y", Speed_y, "time", 1f, "delay", 0, "onupdate", "myUpdateFunction", "EaseType", "linear", "looptype", iTween.LoopType.none ));
	}

    void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "Bullet")
        {
            AudioSource.PlayClipAtPoint(dead, this.transform.position);

            HP--;
            Destroy(colision.gameObject);

            if (HP < 0)
            {
                Destroy(this.gameObject);
                GameObject.Find("GUI").GetComponent<Special_Bar>().Special += 10;
            }
        }
    }
}
