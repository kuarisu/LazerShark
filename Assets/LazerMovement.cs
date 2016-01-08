using UnityEngine;
using System.Collections;

public class LazerMovement : MonoBehaviour {

	void Start () {

        Destroy(gameObject, 2);	
	}
	
    void Update ()
    {
        transform.localPosition = transform.localPosition - transform.right * 0.3f;
    }


}
