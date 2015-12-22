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
            Instantiate(lazer, transform.GetChild(0).transform.position, Quaternion.identity);
            yield return new WaitForSeconds(5);
        }

    }
}
