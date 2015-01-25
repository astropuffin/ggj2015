using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}


    public void restart()
    {
        Application.LoadLevel("Tools");
    }

	// Update is called once per frame
	void Update () {
	
	}
}
