using UnityEngine;
using System.Collections;

public class Canyon_Start : MonoBehaviour {
    Vital.Mission mision;
    
    void Start()
    {
        mision = GameObject.Find("Vital").GetComponent<Vital>().mision;
        
        if (mision != Vital.Mission.Special_bullet)
        {
            Destroy(this.gameObject);
        }
    }
}
