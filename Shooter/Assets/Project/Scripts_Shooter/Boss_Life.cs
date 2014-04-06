using UnityEngine;
using System.Collections;

public class Boss_Life : MonoBehaviour {

    public bool Bullet;
    public bool HitPoints;
    public bool MaxCombo;

    public Vital.Mission Mision;

    void Start()
    {
        Bullet = false;
        HitPoints = false;
        MaxCombo = false;
        Mision = GameObject.Find("Vital").GetComponent<Vital>().mision;
        GameObject.Find("Vital").GetComponent<Vital>().Won_Battle = false;
    }

    void Update()
    {
        if (Bullet == true && Mision == Vital.Mission.Special_bullet)
        {
            Won();
        }

        if (HitPoints == true && Mision == Vital.Mission.HitPoints)
        {
            Won();
        }

        if (MaxCombo == true && Mision == Vital.Mission.Max_combo)
        {
            Won();
        }
    }

    void Won()
    {
        GameObject.Find("Vital").GetComponent<Vital>().Won_Battle = true;
        SMGameEnvironment.Instance.SceneManager.LoadScreen("Story");
    }

    void OnGUI()
    {
        int x = Screen.width /2;
        int y = Screen.height /4;

        if (Mision == Vital.Mission.Special_bullet)
        {
            if (Bullet == false){GUI.Label(new Rect(x, y, 200, 20), "[ ]Kill the boss with a special bullet");}
            else {GUI.Label(new Rect(x, y, 200, 20), "[x]Kill the boss with a special bullet");}
        }

        if (Mision == Vital.Mission.HitPoints)
        {
            if (HitPoints == false){GUI.Label(new Rect(x, y+20, 200, 20), "[ ]Destroy the hit points");}
            else {GUI.Label(new Rect(x, y+20, 200, 20), "[x]Destroy the hit points");}
        }

        if (Mision == Vital.Mission.Max_combo)
        {
            if (MaxCombo == false){GUI.Label(new Rect(x, y+40, 200, 20), "[ ]Make a max combo");}
            else {GUI.Label(new Rect(x, y+40, 200, 20), "[x]Make a max combo");}
        }
    }

}
