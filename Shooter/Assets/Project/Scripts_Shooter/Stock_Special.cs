using UnityEngine;
using System.Collections;

public class Stock_Special : MonoBehaviour {

    public GameObject bullet;
    public GameObject canon;
    public GameObject allied;
    public AudioClip spawn_allied;
    public AudioClip special_bullet;

    public int Max_Timer;
    int Timer_int;

    Vital.Mission mision;

    void Start()
    {
        mision = GameObject.Find("Vital").GetComponent<Vital>().mision;
        Timer_int = 0;
    }

    void Update()
    {
        if (Timer_int > Max_Timer)
        {
            Instantiate(allied, this.transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(spawn_allied, this.transform.position);
            Destroy(this.gameObject);
        }

        Timer_int++;
    }


    void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "Player")
        {
            if (mision == Vital.Mission.Special_bullet)
            {
                AudioSource.PlayClipAtPoint(special_bullet, this.transform.position);
                Instantiate(bullet, canon.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            else
            {
                GameObject GUI_Object = GameObject.Find("GUI");
                GUI_Object.GetComponent<Vital_Variables>().Score(100);
                Destroy(this.gameObject);
            }
        }
    }

}
