using UnityEngine;
using System.Collections;

public class Tool : MonoBehaviour {

    public float useTime;
    float timer;
    public bool inUse;
    public GameObject itemSpot;


	void OnTriggerStay2D( Collider2D collider )
    {
        var ingredient = collider.gameObject.GetComponent<s_ingredient>();
        if( ingredient != null && Input.GetMouseButtonUp( 0 ) )
        {
            ingredient.transform.parent = itemSpot.transform;
            ingredient.transform.localPosition = Vector3.zero;
            inUse = true;
            timer = useTime;
        }
    }
}
