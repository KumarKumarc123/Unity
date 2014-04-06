using UnityEngine;
using System.Collections;

public class Special_Bar : MonoBehaviour {

    public Texture2D bar;
    public GameObject Fuel_Item;
    public bool Filled;
    public int Special;
    public int Fuel;
    public int Minimal_Timer;
    bool Check_once;
	
    void Start()
    {
        Filled = false;

    }

    void Update()
    {
        if (Special >= 100)
        {
            Filled = true;
            Special = 100;
        }

        Fuel--;

        if (Fuel > Minimal_Timer + 100)
        {
            Check_once = true;
        }

        if (Fuel <= 0)
        {
            SMGameEnvironment.Instance.SceneManager.LoadScreen("Game_Over");
            Fuel = 0;
        }

        if (Fuel > 3000)
        {
            Fuel = 3000;
        }

        if (Fuel < Minimal_Timer)
        {
            if (Check_once)
            {
                Instantiate(Fuel_Item, 
                        Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(10, Screen.width - 10), Screen.height, 0))
                        , Quaternion.identity);
                Check_once = false;
            }
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 10), "");
        GUI.DrawTexture(new Rect(0, 0, Special, 10), bar);

        int y = (Screen.height / 4) * 3;

        GUI.Label(new Rect(0, y, 50, 20), "Fuel:");
        GUI.Label(new Rect(0, y+30, 50, 20), Fuel.ToString());
    }
}
