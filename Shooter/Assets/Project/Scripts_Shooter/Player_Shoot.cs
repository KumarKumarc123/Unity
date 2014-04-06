using UnityEngine;
using System.Collections;

public class Player_Shoot : MonoBehaviour {

    public GameObject Bullet, Super_Bullet;
    public AudioClip bullet_shoot;

    public int Timer_Max;
    int Timer;
    public Rect special;

    void Start()
    {
        special = GameObject.FindGameObjectWithTag("Cross").GetComponent<Position_Axes>().Colision;
        Timer = 0;
    }

	void Update () {
	
        if (Input.GetMouseButton(0))
        {
            Timer++;
        } 

        if (Input.GetMouseButtonUp(0))
        {
            if (Timer < Timer_Max)
            {
                if (!special.Contains(Input.mousePosition))
                {
                    Shoot();
                }
            }

            Timer = 0;
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Z))
        {
            if (Timer < Timer_Max)
            {
                Shoot();
            }
        }

	}

    void Shoot()
    {
        Instantiate(Bullet, this.transform.position, Quaternion.identity);
        audio.clip = bullet_shoot;
        audio.Play();
    }
}
