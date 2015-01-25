using UnityEngine;
using System.Collections;

public class textTimer : MonoBehaviour {

	private bool clockStarted;
	private float start;
	public float maxAge = 5f;
	// Use this for initialization
	void Start () {
		clockStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
		checkClock();
	}

	public void startClock(){
//		Debug.Log ("start clock");
		start = Time.realtimeSinceStartup;
		clockStarted = true;
	}

	private void checkClock(){
		if(clockStarted){
			float now = Time.realtimeSinceStartup;
			float difference = now - start;
//			Debug.Log(difference);
			if (difference > maxAge){
				GameObject.Destroy(this.gameObject);
			}
		}
	}

}
