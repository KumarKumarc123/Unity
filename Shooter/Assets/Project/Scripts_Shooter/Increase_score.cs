using UnityEngine;
using System.Collections;
using System;

public class Increase_score : MonoBehaviour {

    public Font KOF;
    public int Score;
    public int Combo;


    void Start()
    {
        Combo = 0;
    }

	public void Change_Score()
    {
        GameObject GUI_Object = GameObject.Find("GUI");
        GUI_Object.GetComponent<Vital_Variables>().Score(Score);
    }

    public void Multiple_Score(int score_new)
    {
        GameObject GUI_Object = GameObject.Find("GUI");
        GameObject variables = GameObject.FindGameObjectWithTag("Vital");
        
        int new_score = score_new * variables.GetComponent<Vital>().Level;
        Combo = score_new / 100;
        if (Combo >= this.GetComponent<Spawn_Enemies>().Max_Enemies)
        {
            GameObject.Find("GUI").GetComponent<Boss_Life>().MaxCombo = true;
        }
        
        GUI_Object.GetComponent<Vital_Variables>().Score(new_score);
    }

    void OnGUI()
    {
        GUIStyle ComboLabel = new GUIStyle();
        ComboLabel.font = KOF;
        ComboLabel.fontSize = 20;
        GUIContent ComboText = new GUIContent();
        ComboText.text = Combo.ToString();
        GUI.Label(new Rect(0, Screen.height/2, 100, 20), ComboText, ComboLabel); 
    }
}
