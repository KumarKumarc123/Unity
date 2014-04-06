using UnityEngine;
using System.Collections;

public class Position_Axes : MonoBehaviour {

    public Texture2D point;
    public GameObject Special_Attack;
    int new_x, new_y;
    public int offset;
    Rect left_border, right_border, top_border, low_border;
    public Rect Colision;

    void Start () {
	
        new_x = Screen.width / 2;
        new_y = Screen.height / 6;

        Vector3 position = new Vector3(new_x, new_y, 0);
        this.transform.position = Camera.main.ScreenToWorldPoint(position);

        left_border = new Rect(new_x - offset, Screen.height -(new_y + offset), 2, offset*2);
        right_border = new Rect(new_x + offset, Screen.height -(new_y + offset), 2, offset*2);
        top_border = new Rect(new_x - offset, Screen.height -(new_y + offset), offset*2, 2);
        low_border = new Rect(new_x - offset, Screen.height - (new_y - offset), offset*2, 2);

        Colision = new Rect(left_border.x, new_y - offset, top_border.width, left_border.height);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player_Shoot>().special = Colision;

	}
	
	// Update is called once per frame
	void Update () {
	
        Vector3 position = this.transform.position;
        position.z = 0;

        this.transform.position = position;

        if (Input.GetMouseButtonUp(0))
        {
            if (Colision.Contains(Input.mousePosition))
            {
                if (GameObject.Find("GUI").GetComponent<Special_Bar>().Filled)
                {
                    Instantiate(Special_Attack, this.transform.position, Quaternion.identity);
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.X))
        {
            if (GameObject.Find("GUI").GetComponent<Special_Bar>().Filled)
            {
                Instantiate(Special_Attack, this.transform.position, Quaternion.identity);
            }
        }

	}

    void OnGUI()
    {

        GUI.DrawTexture(left_border, point);
        GUI.DrawTexture(right_border, point);
        GUI.DrawTexture(top_border, point);
        GUI.DrawTexture(low_border, point);
    }
}

