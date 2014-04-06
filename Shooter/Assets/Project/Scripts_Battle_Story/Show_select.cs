using UnityEngine;
using System.Collections;

public class Show_select : MonoBehaviour {

    public Texture2D play;
    GameObject variables;

    public enum Departamento
    {
        brazil, brazil_amazonia, colombia_centro, ecuador,
        guajira, orinoquia, pacifico_colombia, panama, venezuela_center,
        venezuela_east_up, venezuela_mid_up, venezuela_up
    }

    string Departamento_name;

    public Departamento State;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Vital").GetComponent<Vital>().Lifes <= 0)
        {
            SMGameEnvironment.Instance.SceneManager.LoadScreen("Game_Over");
        }

        variables = GameObject.FindGameObjectWithTag("Vital");

        if (variables.GetComponent<Vital>().first_game == false)
        {
            variables.GetComponent<Vital>().old_departamento = State;
            variables.GetComponent<Vital>().Departamento = State;
            variables.GetComponent<Vital>().first_game = true;
        }
            
        State = variables.GetComponent<Vital>().Departamento;

        if (State != variables.GetComponent<Vital>().old_departamento)
        {
            variables.GetComponent<Vital>().old_departamento = State;
        }

        variables.GetComponent<Vital>().Levels_left = 0;
        GameObject[] levels = GameObject.FindGameObjectsWithTag("Level");

        SelectState(State, true);

        SetAvailable(Departamento.brazil, variables.GetComponent<Vital>().Levels_Status.brazil);
        SetAvailable(Departamento.brazil_amazonia, variables.GetComponent<Vital>().Levels_Status.brazil_amazonia);
        SetAvailable(Departamento.colombia_centro, variables.GetComponent<Vital>().Levels_Status.colombia_centro);
        SetAvailable(Departamento.ecuador, variables.GetComponent<Vital>().Levels_Status.ecuador);
        SetAvailable(Departamento.guajira, variables.GetComponent<Vital>().Levels_Status.guajira);
        SetAvailable(Departamento.orinoquia, variables.GetComponent<Vital>().Levels_Status.orinoquia);
        SetAvailable(Departamento.pacifico_colombia, variables.GetComponent<Vital>().Levels_Status.pacifico_colombia);
        SetAvailable(Departamento.panama, variables.GetComponent<Vital>().Levels_Status.panama);
        SetAvailable(Departamento.venezuela_center, variables.GetComponent<Vital>().Levels_Status.venezuela_center);
        SetAvailable(Departamento.venezuela_east_up, variables.GetComponent<Vital>().Levels_Status.venezuela_east_up);
        SetAvailable(Departamento.venezuela_mid_up, variables.GetComponent<Vital>().Levels_Status.venezuela_mid_up);
        SetAvailable(Departamento.venezuela_up, variables.GetComponent<Vital>().Levels_Status.venezuela_up);

        foreach (GameObject id in levels)
        {
            if (!id.GetComponent<Position>().Level_Completed)
            {
                variables.GetComponent<Vital>().Levels_left++;
            }
        }

        if (GameObject.FindGameObjectWithTag("Vital").GetComponent<Vital>().Levels_left <= 0)
        {
            SMGameEnvironment.Instance.SceneManager.LoadScreen("Win_Scene");
        }
    }

    public void ChangeState(Departamento new_State)
    {
        if (State != new_State)
        {
            SelectState(State, false);
            State = new_State;
            SelectState(new_State, true);
            variables.GetComponent<Vital>().Departamento = new_State;
        }
    }

    void SelectState(Departamento State, bool value)
    {
        switch(State)
        {
            case Departamento.brazil: 
                GameObject.Find("brazil").GetComponent<Position>().Selected = value;
                Departamento_name = "brazil selected";
                break;
            case Departamento.brazil_amazonia:
                GameObject.Find("brazil_amazonia").GetComponent<Position>().Selected = value;
                Departamento_name = "amazonia brasileña selected";
                break;
            case Departamento.colombia_centro:
                GameObject.Find("colombia_centro").GetComponent<Position>().Selected = value;
                Departamento_name = "centro colombiano selected";
                break;
            case Departamento.ecuador:
                GameObject.Find("ecuador").GetComponent<Position>().Selected = value;
                Departamento_name = "ecuador selected";
                break;
            case Departamento.guajira:
                GameObject.Find("guajira").GetComponent<Position>().Selected = value;
                Departamento_name = "guajira selected";
                break;
            case Departamento.orinoquia:
                GameObject.Find("orinoquia").GetComponent<Position>().Selected = value;
                Departamento_name = "orinoquia selected";
                break;
            case Departamento.pacifico_colombia:
                GameObject.Find("pacifico_colombia").GetComponent<Position>().Selected = value;
                Departamento_name = "pacifico colombiano selected";
                break;
            case Departamento.panama:
                GameObject.Find("panama").GetComponent<Position>().Selected = value;
                Departamento_name = "panama selected";
                break;
            case Departamento.venezuela_center:
                GameObject.Find("venezuela_center").GetComponent<Position>().Selected = value;
                Departamento_name = "centro venezolano selected";
                break;
            case Departamento.venezuela_east_up:
                GameObject.Find("venezuela_east_up").GetComponent<Position>().Selected = value;
                Departamento_name = "este venezolano selected";
                break;
            case Departamento.venezuela_mid_up:
                GameObject.Find("venezuela_mid_up").GetComponent<Position>().Selected = value;
                Departamento_name = "llanura venezolana selected";
                break;
            case Departamento.venezuela_up:
                GameObject.Find("venezuela_up").GetComponent<Position>().Selected = value;
                Departamento_name = "arriba venezolano selected";
                break;
        }
    }

    void Draw_Play_Button()
    {
        int x = Screen.width /2;
        int y = Screen.height / 6;
        Rect play_rect = new Rect(x, y*5+30, play.width, play.height);
        GUI.DrawTexture(play_rect, play);
        
        play_rect.y = Screen.height - (play_rect.y + play.height);
        GUI.Label(new Rect(x-100, y*5, 200, 40), Departamento_name);
        
        if (Input.GetMouseButtonUp(0))
        {
            if (play_rect.Contains(Input.mousePosition))
            {
                variables.GetComponent<Vital>().HP = 10;
                variables.GetComponent<Vital>().Level += 1;
                variables.GetComponent<Vital>().Choose_Random_Mission();
                SMGameEnvironment.Instance.SceneManager.LoadScreen("State_Mision");
            }
        }
    }

    void OnGUI()
    {
        if (variables.GetComponent<Vital>().old_departamento != State)
        {
            Draw_Play_Button();
        }
        else
        {
            if(!variables.GetComponent<Vital>().Won_Battle)
            {
                Draw_Play_Button();
            }
        }
        GUI.Label(new Rect(20, 40, 200, 40), "LIFES:");
        GUI.Label(new Rect(20, 60, 200, 40), variables.GetComponent<Vital>().Lifes.ToString());
    }

    void SetAvailable(Departamento State, bool value)
    {
        switch(State)
        {
            case Departamento.brazil: 
                GameObject.Find("brazil").GetComponent<Position>().Level_Completed = value;

                break;
            case Departamento.brazil_amazonia:
                GameObject.Find("brazil_amazonia").GetComponent<Position>().Level_Completed = value;

                break;
            case Departamento.colombia_centro:
                GameObject.Find("colombia_centro").GetComponent<Position>().Level_Completed = value;

                break;
            case Departamento.ecuador:
                GameObject.Find("ecuador").GetComponent<Position>().Level_Completed = value;

                break;
            case Departamento.guajira:
                GameObject.Find("guajira").GetComponent<Position>().Level_Completed = value;

                break;
            case Departamento.orinoquia:
                GameObject.Find("orinoquia").GetComponent<Position>().Level_Completed = value;

                break;
            case Departamento.pacifico_colombia:
                GameObject.Find("pacifico_colombia").GetComponent<Position>().Level_Completed = value;

                break;
            case Departamento.panama:
                GameObject.Find("panama").GetComponent<Position>().Level_Completed = value;

                break;
            case Departamento.venezuela_center:
                GameObject.Find("venezuela_center").GetComponent<Position>().Level_Completed = value;

                break;
            case Departamento.venezuela_east_up:
                GameObject.Find("venezuela_east_up").GetComponent<Position>().Level_Completed = value;

                break;
            case Departamento.venezuela_mid_up:
                GameObject.Find("venezuela_mid_up").GetComponent<Position>().Level_Completed = value;

                break;
            case Departamento.venezuela_up:
                GameObject.Find("venezuela_up").GetComponent<Position>().Level_Completed = value;

                break;
        }
    }
}
