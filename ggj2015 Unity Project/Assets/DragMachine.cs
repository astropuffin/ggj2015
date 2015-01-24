using UnityEngine;
using System.Collections;

public class DragMachine : MonoBehaviour {

    public Collider2D dragTarget;
    public GameObject itemHolder;


	void Update () {

        var mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(mousePoint);
        Debug.Log(Input.mousePosition);


        if(Input.GetMouseButtonDown( 0 ))
        {
            dragTarget = Physics2D.OverlapPoint( mousePoint );
        }

        if( dragTarget != null )
        {
            dragTarget.transform.position = mousePoint;
        }
	}
}
