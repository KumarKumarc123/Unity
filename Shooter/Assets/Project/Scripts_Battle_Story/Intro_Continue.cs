using UnityEngine;
using System.Collections;

public class Intro_Continue : MonoBehaviour {

	void Update () {
	
        if (Input.GetMouseButtonUp(0))
        {
            SMGameEnvironment.Instance.SceneManager.LoadFirstLevel();
        }

	}
}
