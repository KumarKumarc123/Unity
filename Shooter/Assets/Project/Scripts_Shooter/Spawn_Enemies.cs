using UnityEngine;
using System.Collections;

public class Spawn_Enemies : MonoBehaviour {

    bool Timer, Asteroids_Timer, Eater_Timer;
    int int_Timer, Asteroids_Timer_int, Eater_Timer_int;
    public int Max_Timer, Eater_Max_Timer;
    public GameObject Aggressive, Normal, Crazy;
    public GameObject Boss, Asteroids, Eater;
    public int Max_Enemies;


    void Start()
    {
        Timer = false;
        Eater_Timer = true;
        Asteroids_Timer = false;
        Asteroids_Timer_int = 0;
        int_Timer = 0;
        Eater_Timer_int = 0;
    }

	void Update () {
	
        if (int_Timer > Max_Timer)
        {
            Timer = true;
            int_Timer = 0;
        }

        if (Asteroids_Timer_int > Max_Timer * 5)
        {
            Asteroids_Timer = true;
            Asteroids_Timer_int = 0;
        }

        if (Eater_Timer_int > Eater_Max_Timer)
        {
            Eater_Timer_int = 0;
            Eater_Timer = true;
        }

        if (Eater_Timer)
        {
            Eater_Timer = false;
            GameObject[] eater = GameObject.FindGameObjectsWithTag("Eater");
            if (eater.Length < 1)
            {
                Instantiate(Eater, new Vector3(Boss.transform.position.x, Boss.transform.position.y, 0), Quaternion.identity);
            }
        }

        if (Timer)
        {
            Timer = false;

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length < Max_Enemies)
            {
                int Chance = Random.Range(1,4);
                if (Chance == 1)
                {
                    Instantiate(Aggressive, new Vector3(Boss.transform.position.x, Boss.transform.position.y, 0), Quaternion.identity);
                } else if (Chance == 2)
                {
                    Instantiate(Normal, new Vector3(Boss.transform.position.x, Boss.transform.position.y, 0), Quaternion.identity);
                } else if (Chance == 3)
                {
                    Instantiate(Crazy, new Vector3(Boss.transform.position.x, Boss.transform.position.y, 0), Quaternion.identity);
                }

            }
        }

        if (Asteroids_Timer)
        {
            Asteroids_Timer = false;

            Instantiate(Asteroids, Camera.main.ScreenToWorldPoint(new Vector3(0, Random.Range(100, Screen.height - 100), 0)), Quaternion.identity);
        }

        int_Timer++;
        Asteroids_Timer_int++;
        Eater_Timer_int++;

	}
}
