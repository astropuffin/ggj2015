using UnityEngine;
using System.Collections;

public class s_conveyor : MonoBehaviour {

	public GameObject ingredient;
	private float lastObjectTime;
	public float conveyorSpeed;
	public float conveyorLength;
	public float conveyorSpawnDelay;
	// Use this for initialization
	void Start () {
		lastObjectTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		createIngredient();
		advanceIngredients();
		trash();
	}

	//if child is picked up, then release

	//create new object every x tics
	private void createIngredient(){
		float now = Time.realtimeSinceStartup;
		float timeSinceLast = now - lastObjectTime;
		if (timeSinceLast > conveyorSpawnDelay){
			lastObjectTime = now;
			GameObject i_ingredient = Instantiate(ingredient,
			                                      dispensor(),
			                                      new Quaternion(0, 0, 0, 0)) as GameObject;
			i_ingredient.transform.parent = gameObject.transform;
		}
	}

	//move objects to the right every tic
	private void advanceIngredients(){
		foreach (Transform child in gameObject.transform){
			child.localPosition = advancement(child.transform.localPosition);
		}
	}

	//destroy any objects that are too far right
	private void trash(){
		foreach (Transform child in gameObject.transform){
			if (child.transform.localPosition.x > conveyorLength){
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
		return current + new Vector3(conveyorSpeed,0,0);
	}
		                                  
}
