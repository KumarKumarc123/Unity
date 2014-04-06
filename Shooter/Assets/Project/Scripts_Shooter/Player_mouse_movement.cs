using UnityEngine;
using System.Collections;

public class Player_mouse_movement : MonoBehaviour {

    public float Speed;
    public GameObject Player;
    float Speed_x, Speed_y;
    public float Offset;
    public float Time_easing;

	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
	
        Speed_x = 0;
        Speed_y = 0;

        Vector3 player_pos;
        player_pos = Camera.main.WorldToScreenPoint(Player.transform.position);

        Vector3 temp = Player.transform.localScale;
        temp = new Vector3(1, 1, 0);
        Player.transform.localScale = temp;

        if (Input.GetMouseButton(0))
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y > this.transform.position.y)
            {
                Speed_y = Speed;
            } else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < this.transform.position.y)
            {
                Speed_y = -Speed;
            } 

            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < this.transform.position.y + Offset &&
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y > this.transform.position.y - Offset)
            {
                Speed_y = 0;
            }

            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > this.transform.position.x)
            {
                Speed_x = Speed;
            }else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < this.transform.position.x)
            {
                Speed_x = -Speed;
            }

            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < this.transform.position.x + Offset &&
                Camera.main.ScreenToWorldPoint(Input.mousePosition).x > this.transform.position.x - Offset)
            {
                Speed_x = 0;
            }

            float offset_mouse_x = player_pos.x - transform.position.x;

            
            float new_width = (offset_mouse_x * .03f) * Time.deltaTime;

            
            if (Speed_x != 0)
            {
                Vector3 tmp = Player.transform.localScale;
                tmp += new Vector3(new_width, 0, 0);
                Player.transform.localScale = tmp;
            } 

        }

        
        if (player_pos.x < 0)
        {
            player_pos.x = 0;
            Player.transform.position = Camera.main.ScreenToWorldPoint(player_pos);
        }
        
        if (player_pos.x > Screen.width)
        {
            player_pos.x = Screen.width;
            Player.transform.position = Camera.main.ScreenToWorldPoint(player_pos);
        }
        
        if (player_pos.y < 0)
        {
            player_pos.y = 0;
            Player.transform.position = Camera.main.ScreenToWorldPoint(player_pos);
        }
        
        if (player_pos.y > Screen.height)
        {
            player_pos.y = Screen.height;
            Player.transform.position = Camera.main.ScreenToWorldPoint(player_pos);
        }


        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Speed_x = -Speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Speed_x = Speed;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Speed_y = Speed;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            Speed_y = -Speed;
        }

        iTween.MoveAdd(Player.gameObject, iTween.Hash("x", Speed_x, "y", Speed_y, "time", Time_easing, "delay", 0, "onupdate", "myUpdateFunction", "EaseType", "linear", "looptype", iTween.LoopType.none ));
    }
}
