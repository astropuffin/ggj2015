using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum reqType {
	less,
	greater,
	equal
}

public class s_formulaInstance : MonoBehaviour {

	public int[] numReq;// = new int[4]();
	public int formNumber;

	public reqType[] reqTypeArray;// = new reqType[4]();
	public GameObject cauldron;
    public AudioClip achieveSound;
	
	Cauldron c;

	// Use this for initialization
	void Start () {
//		fixSize();
		setValues();
		c = FindObjectOfType<Cauldron>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void fixSize(){
//		RectTransform rt = gameObject.GetComponent<RectTransform>();
//		rt.right = 200;
//		rt.sizeDelta = new Vector2(50,50);
//		rt.localPosition = new Vector3(350,200,0);

	}

	public void achieve(){
		if (checkValid()){
			s_formulaic[] sform = gameObject.GetComponentsInParent<s_formulaic>();
			s_formulaic sform0 = sform[0];
			sform0.achieveFormula(this.gameObject);
			GameObject.Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(achieveSound, Camera.main.transform.position);
			c.dump();
		}
	}

	public bool checkValid(){
		int[] elements = new int[]{c.currentFriendship,c.currentNostalgia,c.currentLaughter,c.currentFulfillment};
		bool valid = true;
		for (int i = 0; i < 4; i++){
			switch (reqTypeArray[i]){
			case reqType.equal:
				if(elements[i] != numReq[i]){
					return valid = false;
				}
				break;
			case reqType.greater:
				if(elements[i] <= numReq[i]){
					return valid = false;
				}
				break;
			case reqType.less:
				if(elements[i] >= numReq[i]){
					return valid = false;
				}
				break;
			}

		}
		return valid;
	}

	public void setValues(){
		foreach (Transform child in gameObject.transform){
			foreach (Transform grandchild in child.transform){
				Debug.Log (grandchild.name.ToString());
				switch (grandchild.name){
				case "Laughter":
					setText(grandchild.gameObject,2);
					break;
				case "Fulfillment":
					setText(grandchild.gameObject,3);
					break;
				case "Friendship":
					setText(grandchild.gameObject,0);
					break;
				case "Nostalgia":
					setText(grandchild.gameObject,1);
					break;
				}
			}
		}
	}
	private void setText(GameObject obj, int num){
		foreach(Transform thing in obj.transform){
			if (thing.name == "Text"){
				Text t = thing.GetComponent<Text>();

				t.text = stringEnum(num) + numReq[num].ToString();
			}
		}
	}
	private string stringEnum(int num){
//		string ret;
		reqType rt = reqTypeArray[num];
		switch(rt){
		case reqType.equal:
			return "=";
		case reqType.greater:
			return ">";
		case reqType.less:
			return "<";
		default:
			return "";
		}
	}
}
