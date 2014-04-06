using UnityEngine;
using System.Collections;

public class Continue_to_Game : MonoBehaviour {

	
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
        GameObject variables = GameObject.FindGameObjectWithTag("Vital");
        variables.GetComponent<Vital>().HP = 10;
        variables.GetComponent<Vital>().Level += 1;
        variables.GetComponent<Vital>().Level_Finished();
        variables.GetComponent<Vital>().Won_Battle = true;

        SMGameEnvironment.Instance.SceneManager.LoadFirstLevel();
    }
}
