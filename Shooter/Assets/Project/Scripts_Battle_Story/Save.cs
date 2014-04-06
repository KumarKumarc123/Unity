using UnityEngine;
using System.Collections;

public class Save : MonoBehaviour {

    public int x, y;
    public Texture2D button;

    void OnGUI()
    {
        Rect cuadrado = new Rect(x, y, button.width, button.height);

        GUI.DrawTexture(cuadrado, button);

        cuadrado.y = Screen.height - button.height;

        if(Input.GetMouseButtonUp(0))
        {
            if (cuadrado.Contains(Input.mousePosition))
            {
                
            }
        }
    }

}
