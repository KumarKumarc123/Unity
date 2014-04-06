using UnityEngine;
using System.Collections;

public class Go_Back_Title : MonoBehaviour {

    GameObject variables;
    int score;

    void Start()
    {
        variables = GameObject.FindGameObjectWithTag("Vital");
        score = variables.GetComponent<Vital>().score;
    }
    
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 50, 20), "Score:");
        GUI.Label(new Rect(10, 25, 50, 20), score.ToString());
    }
	
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
        SMGameEnvironment.Instance.SceneManager.LoadScreen("Title");
        
        variables = GameObject.FindGameObjectWithTag("Vital");
        Destroy(variables);
    }
}
