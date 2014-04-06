using UnityEngine;
using System.Collections;

public class Player_Collision : MonoBehaviour {

    public AudioClip Player_Dead;

    void Vibrate()
    {
        GameObject camara = Camera.main.gameObject;
        iTween.ShakePosition(camara, new Vector3(0.3f, 0.3f, 0.3f), 1f);
    #if UNITY_ANDROID
        Handheld.Vibrate();
    #endif
    }

	void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "Bullet_Enemy")
        {
            Vibrate();
            AudioSource.PlayClipAtPoint(Player_Dead, this.transform.position);
            GameObject GUI_Object = GameObject.Find("GUI");
            GUI_Object.GetComponent<Vital_Variables>().Damage(1);
            Destroy(colision.gameObject);
        }

        if (colision.gameObject.tag == "Enemy_Super")
        {
            Vibrate();
            AudioSource.PlayClipAtPoint(Player_Dead, this.transform.position);
            GameObject GUI_Object = GameObject.Find("GUI");
            GUI_Object.GetComponent<Vital_Variables>().Damage(3);
            Destroy(colision.gameObject);
        }

        if (colision.gameObject.tag == "Asteroid")
        {
            Vibrate();
            AudioSource.PlayClipAtPoint(Player_Dead, this.transform.position);
            GameObject GUI_Object = GameObject.Find("GUI");
            GUI_Object.GetComponent<Vital_Variables>().Damage(5);
            Destroy(colision.gameObject);
        }
    }
}
