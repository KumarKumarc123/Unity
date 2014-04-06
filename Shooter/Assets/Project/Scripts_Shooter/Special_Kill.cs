using UnityEngine;
using System.Collections;

public class Special_Kill : MonoBehaviour {

    public Vector3 scale;
    public GameObject dead_smoke;

    public void Kill_Enemies()
    {
        GameObject GUI_bar = GameObject.Find("GUI");
        GUI_bar.GetComponent<Special_Bar>().Special = 0;
        GUI_bar.GetComponent<Special_Bar>().Filled = false;


        Vector3 new_pos = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector3 pos = Camera.main.ScreenToWorldPoint(new_pos);
        pos.z = 0;
        this.transform.position = pos;

        this.transform.localScale = scale;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject GUI_Object = GameObject.Find("GUI");

        int Combo = 0;

        foreach (GameObject id in enemies)
        {
            Combo++;
            Instantiate(dead_smoke, id.transform.position, Quaternion.identity);
            Destroy(id.gameObject);
        }

        GUI_Object.GetComponent<Increase_score>().Multiple_Score(Combo*100);

        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet_Enemy");

        foreach (GameObject id in bullets)
        {
            Destroy(id.gameObject);
        }
        
        bullets = GameObject.FindGameObjectsWithTag("Bullet");
        
        foreach (GameObject id in bullets)
        {
            Destroy(id.gameObject);
        }

        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject id in asteroids)
        {
            id.GetComponent<Asteroids_Collision>().HP = -1;
        }
    }

    public void Delete()
    {
        Destroy(this.gameObject);
    }

}
