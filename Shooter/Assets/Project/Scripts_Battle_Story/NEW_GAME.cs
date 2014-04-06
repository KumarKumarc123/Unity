using UnityEngine;
using System.Collections;

public class NEW_GAME : MonoBehaviour {

    public Texture2D texture;
    int x, y;

    void Start()
    {
        x = (Screen.width / 2) - (texture.width /2);
        y = Screen.height / 4;
    }

    void OnGUI()
    {
        Rect cuadrado = new Rect(x, y, texture.width, texture.height);
        GUI.DrawTexture(cuadrado, texture);

        cuadrado.y = Screen.height - (cuadrado.y + texture.height);

        if (Input.GetMouseButtonUp(0))
        {
            if (cuadrado.Contains(Input.mousePosition))
            {
                SMGameEnvironment.Instance.SceneManager.LoadScreen("Intro_Story");
            }
        }
    }

}
