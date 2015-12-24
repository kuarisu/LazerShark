using UnityEngine;
using System.Collections;

public class LazerShot : MonoBehaviour {

    public GameObject lazer;
    private bool shooting = false;

    void OnTriggerExit(Collider col)
    {
        if ( col.gameObject.tag == "Water" && shooting == false)
        {
            shooting = true;
            StartCoroutine(ShootLazer());
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Water")
        {
            shooting = false;
            StopCoroutine("ShootLazer");
        }
    }

    IEnumerator ShootLazer()
    {
        while (shooting == true)
        {
            Instantiate(lazer, transform.position + transform.up, transform.rotation * Quaternion.Euler(0,0,-90));
            yield return new WaitForSeconds(0.75f);
        }

    }
}
