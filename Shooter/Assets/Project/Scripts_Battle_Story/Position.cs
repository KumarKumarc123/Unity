using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

    public bool Selected;
    public bool Level_Completed;

    public Show_select.Departamento State;

	void Update () {
	
        if (!Level_Completed)
        {
            if (!Selected)
            {
                renderer.material.color = Color.gray;
            }
            else
            {
                renderer.material.color = Color.white;
            }
        }
        else
        {
            renderer.material.color = Color.red;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mouseposition = Input.mousePosition;
            mouseposition.z = 10;

            if (!Level_Completed)
            {
                if (this.gameObject.GetComponent<PolygonCollider2D>().OverlapPoint(
                    Camera.main.ScreenToWorldPoint(mouseposition)))
                {
                    if (!Selected)
                    {
                        Selected = true;
                    }

                    GameObject.Find("GUI").GetComponent<Show_select>().ChangeState(State);
                }
            }
        }

	}
}


