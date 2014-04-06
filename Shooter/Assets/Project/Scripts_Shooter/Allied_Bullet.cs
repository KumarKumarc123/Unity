using UnityEngine;
using System.Collections;

public class Allied_Bullet : MonoBehaviour {

    Vector3 Enemy_Target;
    public float Speed;

	void Start () {
	
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 1)
        {
            Vector3 min_target = enemies [0].transform.position;

            foreach (GameObject id in enemies)
            {
                float old_dist = Vector3.Distance(this.transform.position, min_target);
                float new_dist = Vector3.Distance(this.transform.position, id.transform.position);

                if (new_dist < old_dist)
                {
                    min_target = id.transform.position;
                }
            }

            Enemy_Target = min_target;

        } else
        {
            Destroy(this.gameObject);
        }

        Enemy_Target = (Enemy_Target - this.transform.position).normalized;
	}
	
	
	void Update () {
	
        Vector3 new_dir = Enemy_Target * Speed;
        
        iTween.MoveAdd(this.gameObject, iTween.Hash("x", new_dir.x, "y", new_dir.y, "time", 1f, "delay", 0, "onupdate", "myUpdateFunction", "EaseType", "linear", "looptype", iTween.LoopType.none ));

        if (Vector3.Distance(this.transform.position, Camera.main.transform.position) > 13)
        {
            Destroy(this.gameObject);
        }

	}
}
