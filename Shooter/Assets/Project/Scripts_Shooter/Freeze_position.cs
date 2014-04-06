using UnityEngine;
using System.Collections;

public class Freeze_position : MonoBehaviour {

    float old_y;

	void Start () {
	
        old_y = this.transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {

        Vector3 old_pos = this.transform.position;
        old_pos.y = old_y;
        Quaternion old_rot = this.transform.rotation;
        old_rot.z = 5;

        this.transform.position = old_pos;
        this.transform.rotation = old_rot;

	}
}
