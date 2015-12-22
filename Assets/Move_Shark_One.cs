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
}
