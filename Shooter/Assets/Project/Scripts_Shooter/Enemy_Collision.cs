using UnityEngine;
using System.Collections;

public class Enemy_Collision : MonoBehaviour {
    	
    public GameObject Dead_Smoke;
    public AudioClip Dead_Sound;


    void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "Bullet")
        {
            AudioSource.PlayClipAtPoint(Dead_Sound, this.transform.position);

            GameObject GUI_Object = GameObject.Find("GUI");
            GUI_Object.GetComponent<Increase_score>().Change_Score();
            Instantiate(Dead_Smoke, this.transform.position, Quaternion.identity);

            GUI_Object.GetComponent<Special_Bar>().Special++;

            Destroy(colision.gameObject);
            Destroy(this.gameObject);

        }

        if (colision.gameObject.tag == "Asteroid")
        {
            int Chance = Random.Range(1, 4);

            switch(Chance)
            {
                case 1: this.GetComponent<Enemy_Move>().Behaviour = Enemy_Move.Mood.Aggressive;
                    break;
                case 2: this.GetComponent<Enemy_Move>().Behaviour = Enemy_Move.Mood.Normal;
                    break;
                case 3: this.GetComponent<Enemy_Move>().Behaviour = Enemy_Move.Mood.Crazy;
                    break;
            }

            Destroy(colision.gameObject);

        }
    }
}
