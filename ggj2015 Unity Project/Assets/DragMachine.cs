using UnityEngine;
using System.Collections;

public class DragMachine : MonoBehaviour {

    public Collider2D dragTarget;
    public Tool[] tools;

	void Update () {

        var mousePoint = Camera.main.ScreenToWorldPoint( new Vector3( Input.mousePosition.x, Input.mousePosition.y, 10) );

        if(Input.GetMouseButtonDown( 0 ))
        {
            dragTarget = Physics2D.OverlapPoint( mousePoint );

            if( dragTarget != null && dragTarget.GetComponent<Dragger>() != null )
            {
                dragTarget.transform.parent = null;
            }
            else
            {
                dragTarget = null;
            }

        }

        if( dragTarget != null )
        {
            dragTarget.transform.position = mousePoint;
        }

        if( Input.GetMouseButtonUp( 0 ) )
        {
            
            var tool = Physics2D.OverlapPoint(mousePoint, 1 << LayerMask.NameToLayer("Tools"));
            if(tool != null && dragTarget != null )
            {
                tool.GetComponent<Tool>().acceptItem(dragTarget.GetComponent<s_ingredient>());
            }
            dragTarget = null;
        }
	}
}
