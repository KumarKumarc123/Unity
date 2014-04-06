using UnityEngine;
using System.Collections;

public class Begun_Game : MonoBehaviour {

    public AudioClip Start;

	void Update () {
	
        if (Input.GetMouseButtonUp(0))
        {
            Code();
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Z))
        {
            Code();
        }

	}

    void Code()
    {
        AudioSource.PlayClipAtPoint(Start, this.transform.position);
        SMGameEnvironment.Instance.SceneManager.LoadScreen("Load_Screen");
    }
}
