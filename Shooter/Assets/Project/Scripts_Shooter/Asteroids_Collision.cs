using UnityEngine;
using System.Collections;

public class Asteroids_Collision : MonoBehaviour {

    public int HP;
    public GameObject Coin_Super;
    public AudioClip Spawn_Star;
    public AudioClip Player_Hit;

	void Start () {
        HP = 3;	
	}
	
	
	void Update () {
	
        if (HP < 0)
        {
            Destroy(this.gameObject);
            int Chance = Random.Range(1, 3);
            if (Chance == 2)
            {
                AudioSource.PlayClipAtPoint(Spawn_Star, this.transform.position);
                Instantiate(Coin_Super, this.transform.position, Quaternion.identity);
            }
        }

	}

    void OnCollisionEnter2D(Collision2D colision)
    {
#if UNITY_ANDROID
        Handheld.Vibrate();
#endif

        if (colision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(Player_Hit, this.transform.position);

            GameObject[] allied = GameObject.FindGameObjectsWithTag("Allied");

            foreach(GameObject id in allied)
            {
                Destroy(id.gameObject);
            }
        }

        if (colision.gameObject.tag == "Bullet")
        {
            AudioSource.PlayClipAtPoint(Player_Hit, this.transform.position);
            HP--;
        }

    }
}
