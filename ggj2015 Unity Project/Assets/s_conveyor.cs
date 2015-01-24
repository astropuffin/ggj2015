using UnityEngine;
using System.Collections;

public class s_conveyor : MonoBehaviour {

	public GameObject ingredient;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//if child is picked up, then release

	//create new object every x tics
	private void createIngredient(){
		GameObject i_ingredient = Instantiate(ingredient,
		                                      dispensor(),
		                                      new Quaternion(0, 0, 0, 0)) as GameObject;
		i_ingredient.transform.parent = gameObject.transform;

	}

	//move objects to the right every tic
	private void advanceIngredients(){
		foreach (Transform t in gameObject.transform.GetComponentsInChildren<Transform>()) {
			t.localPosition = advancement(transform.localPosition);
		}
	}

	//destroy any objects that are too far right
	private void trash(){
		foreach (Transform child in gameObject.transform.GetComponentInChildren<Transform>()){
			if (child.localPosition.y > 10) {
				GameObject.Destroy(child.gameObject);
			}
		}
	}

	//determines the location of the despensor
	private Vector3 dispensor(){
		return new Vector3(0,0,0);
	}

	//determines the advancement speed of the conveyor belt
	private Vector3 advancement(Vector3 current){
		return current + new Vector3(0,1,0);
	}
		                                  
}
