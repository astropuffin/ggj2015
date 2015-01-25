using UnityEngine;
using System.Collections;

public class ToolTipper : MonoBehaviour {


    public GameObject blender, oven, still, blenderTip, ovenTip, stillTip;
    public float tipHeight;


	// Use this for initialization
	void Start () {
        blenderTip.transform.position = Camera.main.WorldToScreenPoint(blender.transform.position) + Vector3.up * tipHeight;
        ovenTip.transform.position = Camera.main.WorldToScreenPoint(oven.transform.position) + Vector3.up * tipHeight;
        stillTip.transform.position = Camera.main.WorldToScreenPoint(still.transform.position) + Vector3.up * tipHeight;
	}
	
	
}
