using UnityEngine;
using System.Collections;

public class HitPointsCollision : MonoBehaviour {

    public GameObject Smoke;

    void OnCollisionEnter2D(Collision2D colision)
    {
        Debug.Log(colision);
        if (colision.gameObject.tag == "Explosion")
        {
            Instantiate(Smoke, this.transform.position, Quaternion.identity);
            GameObject.Find("GUI").GetComponent<HitPointsSpawn>().Points--;
            GameObject.Find("GUI").GetComponent<HitPointsSpawn>().HitDead();
            Destroy(this.gameObject);
        }
    }

}
