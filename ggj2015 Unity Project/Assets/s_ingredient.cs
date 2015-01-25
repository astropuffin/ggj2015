using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class s_ingredient : MonoBehaviour {

	public enum ingredientType {
		teddy,
		shoe,
		mushroom,
		helmet
	}

	public enum toolTypes {
		boiler,
		grinder,
		grater
	}

	public ingredientType i_type;

	//add the sprites
	private Dictionary<ingredientType,Sprite> d_Sprite = new Dictionary<ingredientType, Sprite>();
	public Sprite s_teddy;
	
	Dictionary<ingredientType,Dictionary<toolTypes,int[]>> elements = new Dictionary<ingredientType,Dictionary<toolTypes,int[]>>();

	void Start () {
		loadSprites();
		makeRandomIngredient();
		assignSprite();
		populateData();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int[] getElements(toolTypes ttype){
		return elements[ingredientType.teddy][ttype];
	}

	public void makeRandomIngredient(){
		i_type = ingredientType.teddy;
	}

	private void loadSprites(){
		
		d_Sprite.Add(ingredientType.teddy,s_teddy);
	}

	void populateData(){
		Dictionary<toolTypes,int[]> d_teddy = new Dictionary<toolTypes, int[]>();
		d_teddy.Add(toolTypes.boiler,new int[]{1,0,0,0});
		elements.Add(ingredientType.teddy,d_teddy);

//		int[,,] element_output = new int[,,]{
//			{{1,0,0,0},{2,0,0,0},{2,1,0,0}},
//			{{0,0,0,1},{0,0,0,2},{1,0,0,2}},
//			{{0,0,1,0},{0,0,2,0},{0,0,2,1}},
//			{{0,0,0,0},{0,0,0,0},{0,0,0,0}}
//		}


	}

	void assignSprite(){
//		GetComponent("SpriteRenderer").sprite = d_Sprite(i_type);
		GetComponent<SpriteRenderer>().sprite = d_Sprite[i_type];
	}

}