using UnityEngine;
using System.Collections;

public class Boss_Colision : MonoBehaviour {

    public AudioClip Boss_Death;
    public GameObject Explosion;
    Vital.Mission mision;

    void Start()
    {
        mision = GameObject.Find("Vital").GetComponent<Vital>().mision;

        if (mision != Vital.Mission.Special_bullet)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "Special_Bullet")
        {
            AudioSource.PlayClipAtPoint(Boss_Death, this.transform.position);
            Instantiate(Explosion, this.transform.position, Quaternion.identity);
            GameObject.Find("GUI").GetComponent<Boss_Life>().Bullet = true;
            Destroy(this.gameObject);
        }
    }
}
