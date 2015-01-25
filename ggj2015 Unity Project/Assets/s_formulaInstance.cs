using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum reqType {
	less,
	greater,
	equal
}

public class s_formulaInstance : MonoBehaviour {

	public int[] numReq;// = new int[4]();
	public int formNumber;

	public reqType[] reqTypeArray;// = new reqType[4]();

	// Use this for initialization
	void Start () {
		fixSize();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void fixSize(){
		RectTransform rt = gameObject.GetComponent<RectTransform>();
//		rt.right = 200;
//		rt.sizeDelta = new Vector2(50,50);
//		rt.localPosition = new Vector3(350,200,0);

	}

	public void achieve(){
		s_formulaic[] sform = gameObject.GetComponentsInParent<s_formulaic>();
		s_formulaic sform0 = sform[0];
		sform0.achieveFormula(this.gameObject);
		GameObject.Destroy(this.gameObject);
	}
}
