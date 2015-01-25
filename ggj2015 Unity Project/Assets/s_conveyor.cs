using UnityEngine;
using System.Collections;

public class s_conveyor : MonoBehaviour {

	public GameObject ingredient;
	private float lastObjectTime;
	public float conveyorSpeed;
	public float conveyorLength;
	public float conveyorSpawnDelay;
    public GameObject trashGo;
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



    IEnumerator trashIngredient( GameObject go)
    {
        Destroy(go.GetComponent<GlobalTween>() );
        go.AddComponent<spinner>();
        TweenPosition.Begin(go.gameObject, .2f, trashGo.transform.position + Vector3.up * 2);
        yield return new WaitForSeconds(.3f);
        TweenPosition.Begin(go.gameObject, .4f, trashGo.transform.position);
        yield return new WaitForSeconds(.5f);
        Destroy(go);
    }

	//destroy any objects that are too far right
	private void trash(){

        
		foreach (Transform child in gameObject.transform){
			if (child.transform.localPosition.x > conveyorLength){
                child.parent = null;
                StartCoroutine( trashIngredient(child.gameObject));
				
			}
		}
	}

	//determines the location of the despensor
	private Vector3 dispensor(){
        return transform.position;
	}

	//determines the advancement speed of the conveyor belt
	private Vector3 advancement(Vector3 current){
		return current + new Vector3(conveyorSpeed,0,0);
	}
		                                  
}
