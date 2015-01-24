using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {

  
    public static GameObject tooltipPrefab;
    public Text nostalgia, laughter, fulfillment, friendship;


    public static GameObject makeToolTip( int n, int l, int fr, int fu)
    {
        var result = Instantiate(tooltipPrefab) as GameObject;

        var tooltip = result.GetComponent<Tooltip>();
        
        return result;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	
}
