﻿using UnityEngine;
using System.Collections;

public class spinner : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles += new Vector3(0, 0, 1) * 400 * Time.deltaTime;
	}
}
