using UnityEngine;
using System.Collections;

public class Vital : MonoBehaviour {

    public int HP;
    public int score;
    public int Level;
    public int Max_Enemies;
    public int Lifes;
    public bool Won_Battle;
    public Show_select.Departamento Departamento, old_departamento;
    public bool first_game;
    public int Levels_left;
    public Levels_Complete Levels_Status;

    public enum Mission
    {
        Special_bullet, Max_combo, HitPoints
    }
    public Mission mision;

    public struct Levels_Complete
    {
        public bool brazil, brazil_amazonia, colombia_centro, ecuador,
        guajira, orinoquia, pacifico_colombia, panama, venezuela_center,
        venezuela_east_up, venezuela_mid_up, venezuela_up;
    }

	void Awake()
	{
		DontDestroyOnLoad (this.gameObject);
	}

    void Start()
    {
        Won_Battle = false;
        first_game = false;

        Levels_Status = new Levels_Complete();
        Levels_Status.brazil = false;
        Levels_Status.brazil_amazonia = false;
        Levels_Status.colombia_centro = false;
        Levels_Status.ecuador = false;
        Levels_Status.guajira = false;
        Levels_Status.orinoquia = false;
        Levels_Status.pacifico_colombia = false;
        Levels_Status.panama = false;
        Levels_Status.venezuela_center = false;
        Levels_Status.venezuela_east_up = false;
        Levels_Status.venezuela_mid_up = false;
        Levels_Status.venezuela_up = false;
    }

    public void Level_Finished()
    {
        switch(Departamento)
        {
            case Show_select.Departamento.brazil:
                Levels_Status.brazil = true;
                break;
            case Show_select.Departamento.brazil_amazonia:
                Levels_Status.brazil_amazonia = true;
                break;
            case Show_select.Departamento.colombia_centro:
                Levels_Status.colombia_centro = true;
                break;
            case Show_select.Departamento.ecuador:
                Levels_Status.ecuador = true;
                break;
            case Show_select.Departamento.guajira:
                Levels_Status.guajira = true;
                break;
            case Show_select.Departamento.orinoquia:
                Levels_Status.orinoquia = true;
                break;
            case Show_select.Departamento.pacifico_colombia:
                Levels_Status.pacifico_colombia = true;
                break;
            case Show_select.Departamento.panama:
                Levels_Status.panama = true;
                break;
            case Show_select.Departamento.venezuela_center:
                Levels_Status.venezuela_center = true;
                break;
            case Show_select.Departamento.venezuela_east_up:
                Levels_Status.venezuela_east_up = true;
                break;
            case Show_select.Departamento.venezuela_mid_up:
                Levels_Status.venezuela_mid_up = true;
                break;
            case Show_select.Departamento.venezuela_up:
                Levels_Status.venezuela_up = true;
                break;
        }
    }

    public void Choose_Random_Mission()
    {
        int chance = Random.Range(1, 4);

        switch(chance)
        {
            case 1: mision = Mission.Special_bullet;
                break;
            case 2: mision = Mission.HitPoints;
                break;
            case 3: mision = Mission.Max_combo;
                break;
        }
    }
}
