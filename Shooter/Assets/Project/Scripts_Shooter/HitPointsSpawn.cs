using UnityEngine;
using System.Collections;

public class HitPointsSpawn : MonoBehaviour {

    public GameObject Hitpoint;
    public int Points;

    Vital.Mission mision;

	void Start () {
	
        mision = GameObject.Find("Vital").GetComponent<Vital>().mision;

        if (mision == Vital.Mission.HitPoints)
        {

        int x = Screen.height / 4;

        int y = Screen.height / 6;

        Instantiate(Hitpoint, Camera.main.ScreenToWorldPoint(new Vector3(x, y*2, 1)), Quaternion.identity);
        Instantiate(Hitpoint, Camera.main.ScreenToWorldPoint(new Vector3(x, y*3, 1)), Quaternion.identity);
        Instantiate(Hitpoint, Camera.main.ScreenToWorldPoint(new Vector3(x, y*4, 1)), Quaternion.identity);

        Instantiate(Hitpoint, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - x, y*2, 1)), Quaternion.identity);
        Instantiate(Hitpoint, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - x, y*3, 1)), Quaternion.identity);
        Instantiate(Hitpoint, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - x, y*4, 1)), Quaternion.identity);

        Points += 6;

        }

	}

    public void HitDead()
    {
        if (Points <= 0)
        {
            GameObject.Find("GUI").GetComponent<Boss_Life>().HitPoints = true;
        }
    }
}
