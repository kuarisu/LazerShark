using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "laser")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Debug.Log("GOAL!");
        }

    }
}
