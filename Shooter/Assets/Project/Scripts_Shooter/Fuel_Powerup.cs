using UnityEngine;
using System.Collections;

public class Fuel_Powerup : MonoBehaviour {

    public int Life_Add;

    void Start()
    {
        Vector3 pos = this.transform.position;
        pos.z = 0;
        this.transform.position = pos;

        Life_Add = GameObject.Find("GUI").GetComponent<Special_Bar>().Minimal_Timer + 150;
    }

	void OnCollisionEnter2D (Collision2D colision)
    {
        if (colision.gameObject.tag == "Player")
        {
            GameObject.Find("GUI").GetComponent<Special_Bar>().Fuel += Life_Add;
            Destroy(this.gameObject);
        }
    }
}
