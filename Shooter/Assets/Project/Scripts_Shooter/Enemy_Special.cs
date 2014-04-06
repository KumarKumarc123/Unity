using UnityEngine;
using System.Collections;

public class Enemy_Special : MonoBehaviour {

    public int Speed;
    int Speed_x, Speed_y;
    public int Timer_Max;
    int Timer;
    public AudioClip Special_sound;

    void Start()
    {
        Timer = 0;
        AudioSource.PlayClipAtPoint(Special_sound, this.transform.position);
    }

	void Update () {
	
        if (Timer > Timer_Max)
        {
            Destroy(this.gameObject);
        }

        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Target(Player.transform.position);

        this.transform.Translate(new Vector3(Speed_x, Speed_y, 0) * Time.deltaTime, Space.World);

        Timer++;

	}

    void Target(Vector3 target)
    {
        
        if (target.x > this.transform.position.x)
        {
            Speed_x = Speed;
        } else if (target.x < this.transform.position.x)
        {
            Speed_x = -Speed;
        } else
        {
            Speed_x = 0;
        }
        if (target.y > this.transform.position.y)
        {
            Speed_y = Speed;
        } else if (target.y < this.transform.position.y)
        {
            Speed_y = -Speed;
        } else
        {
            Speed_y = 0;
        }
        
    }
}
