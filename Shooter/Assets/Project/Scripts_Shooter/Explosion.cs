using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    void Start()
    {
        Debug.Log(this.transform.position);
    }

    public void Delete()
    {
        Destroy(this.gameObject);
    }
}
