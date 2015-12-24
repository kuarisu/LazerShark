using UnityEngine;
using System.Collections;

public class Move_Shark_One : MonoBehaviour {


    public GameObject RightForce;
    public GameObject LeftForce;
    private int speedForce = 275;
    private float coolDown = 1;
    private bool moveOKleft = true;
    private bool moveOKright = true;


    void Update()
    {
        if (Input.GetKeyUp("l") && moveOKleft)
        {
            StartCoroutine(LeftMovement());
        }
        if (Input.GetKeyUp("m") && moveOKright)
        {
            StartCoroutine(RightMovement());
        }

    }

    //Coroutine ajout force à gauche du Player_One
    IEnumerator LeftMovement()
    {
        moveOKleft = false;
        GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * speedForce, LeftForce.transform.position);
        yield return new WaitForSeconds(coolDown);
        moveOKleft = true;

    }

    //Coroutine ajout force à droite du PLayer_One
    IEnumerator RightMovement()
    {
        moveOKright = false;
        GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * speedForce, RightForce.transform.position);
        yield return new WaitForSeconds(coolDown);
        moveOKright = true;
    }


    //Triger avec la Zone Mortel (mort) et avec le laser (immobilisation)
    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "DeathZone")
        {
            Destroy(gameObject);
            Debug.Log("You died player 1");
        }

        if (col.gameObject.tag == "laser")
        {
            Debug.Log("je touche je touche !");
            Destroy(col.gameObject);
            StartCoroutine(Immobilisation());
        }
    }

    IEnumerator Immobilisation()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        yield return new WaitForSeconds(2);
    }
}
