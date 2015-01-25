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

                foreach (var item in tools)
                {
                    if( !item.inUse )
                    {
                        var elements = dragTarget.GetComponent<s_ingredient>().getElements( item.toolType );
                        item.tooltip.gameObject.SetActive(true);
                        //friendships nostalgia, laughter, fulfillment
                        item.tooltip.setToolTip(elements[1], elements[2], elements[0], elements[3]);
                    }
                }


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

            foreach (var item in tools)
            {
                if( !item.inUse)
                {
                    item.tooltip.gameObject.SetActive(false);
                }
            }

            dragTarget = null;
        }
	}
}
