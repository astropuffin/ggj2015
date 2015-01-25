using UnityEngine;
using System.Collections;

public class GlobalTween : MonoBehaviour {

    public GameObject tweenKing;

	
	// Update is called once per frame
	void Update () {
        transform.rotation = tweenKing.transform.rotation;
        transform.localScale = tweenKing.transform.localScale;
	}
}
