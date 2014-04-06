using UnityEngine;
using System.Collections;

public class Mision_State : MonoBehaviour {

    Vital.Mission mision;

    void Start()
    {
        mision = GameObject.Find("Vital").GetComponent<Vital>().mision;
    }

	void Update () {

        if (Input.GetMouseButtonUp(0))
        {
            SMGameEnvironment.Instance.SceneManager.LoadLevel("main");
        }

	}

    void OnGUI()
    {
        int x = 0;
        int y = Screen.height / 2;
        Rect label_rect = new Rect(x, y, 300, 50);
        Rect label_rect2 = label_rect;
        label_rect2.y += 40;
        GUIStyle style = new GUIStyle();
        style.fontSize = 20;

        if (mision == Vital.Mission.HitPoints)
        {
            GUI.Label(label_rect, "YOUR MISSION:", style);
            GUI.Label(label_rect2, "KILL THE HIT POINTS", style);
        }

        if (mision == Vital.Mission.Max_combo)
        {
            GUI.Label(label_rect, "YOUR MISSION:", style);
            GUI.Label(label_rect2, "MAKE A MAX COMBO", style);
        }

        if (mision == Vital.Mission.Special_bullet)
        {
            GUI.Label(label_rect, "YOUR MISSION:", style);
            GUI.Label(label_rect2, "KILL THE BOSS WITH THE SPECIAL BULLET", style);
        }
    }
}
