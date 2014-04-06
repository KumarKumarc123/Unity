using UnityEngine;
using System.Collections;

public class Vital_Variables : MonoBehaviour {

    GameObject variables;
    int Life_Game_Over;

    void Start()
    {
        variables = GameObject.FindGameObjectWithTag("Vital");
        Life_Game_Over = variables.GetComponent<Vital>().Lifes - 1;
    }

    void Update()
    {
        if ( variables.GetComponent<Vital>().HP < 1)
        {
            variables.GetComponent<Vital>().Lifes = Life_Game_Over;
            variables.GetComponent<Vital>().Won_Battle = false;
            SMGameEnvironment.Instance.SceneManager.LoadFirstLevel();
        }
    }

    public void Damage(int damage)
    {
        variables.GetComponent<Vital>().HP -= damage;
    }

    public void Score(int score)
    {
        variables.GetComponent<Vital>().score += score * variables.GetComponent<Vital>().Level;
    }

    void OnGUI(){

        GUI.Label(new Rect(0, 20, 100, 20), "score:");
        GUI.Label(new Rect(0, 40, 100, 20), variables.GetComponent<Vital>().score.ToString());
        GUI.Label(new Rect(0, 60, 100, 20), "Armor:");
        GUI.Label(new Rect(0, 80, 100, 20), variables.GetComponent<Vital>().HP.ToString());
        GUI.Label(new Rect(0, 100, 100, 20), "Level:");
        GUI.Label(new Rect(0, 120, 100, 20), variables.GetComponent<Vital>().Level.ToString());

    }
}
