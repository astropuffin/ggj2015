using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class s_ingredient : MonoBehaviour {

	public enum ingredientType {
		teddy,
		mushroom,
		hammer
	}

	public enum toolTypes {
		blender,
		oven,
		still
	}

	public ingredientType i_type;

	//add the sprites
	private Dictionary<ingredientType,Sprite> d_Sprite = new Dictionary<ingredientType, Sprite>();
	public Sprite s_teddy;
	public Sprite s_mushroom;
	public Sprite s_hammer;
	
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
		return elements[i_type][ttype];
	}

	public void makeRandomIngredient(){
		Array values = Enum.GetValues(typeof(ingredientType));
		i_type = (ingredientType)values.GetValue(UnityEngine.Random.Range (0,values.Length));
	}

	private void loadSprites(){
		
		d_Sprite.Add(ingredientType.teddy,s_teddy);
		d_Sprite.Add(ingredientType.mushroom, s_mushroom);
		d_Sprite.Add(ingredientType.hammer,s_hammer);
	}
	
	public Dictionary<ingredientType,string[]> quips = new Dictionary<ingredientType, string[]>();

	private void loadQuips(){
		quips.Add(ingredientType.hammer,new string[]{"stuff","things"});
	}

	void populateData(){
		Dictionary<toolTypes,int[]> d_teddy = new Dictionary<toolTypes, int[]>();
		d_teddy.Add(toolTypes.blender,new int[]{1,0,0,0});
		d_teddy.Add(toolTypes.oven,new int[]{2,0,0,0});
		d_teddy.Add(toolTypes.still,new int[]{2,1,0,0});
		elements.Add(ingredientType.teddy,d_teddy);

		Dictionary<toolTypes,int[]> d_mushroom = new Dictionary<toolTypes, int[]>();
		d_mushroom.Add(toolTypes.blender,new int[]{0,0,1,0});
		d_mushroom.Add(toolTypes.oven,new int[]{0,0,2,0});
		d_mushroom.Add(toolTypes.still,new int[]{0,0,2,1});
		elements.Add(ingredientType.mushroom,d_mushroom);

		Dictionary<toolTypes,int[]> d_hammer = new Dictionary<toolTypes, int[]>();
		d_hammer.Add(toolTypes.blender,new int[]{0,0,0,1});
		d_hammer.Add(toolTypes.oven,new int[]{1,0,0,1});
		d_hammer.Add(toolTypes.still,new int[]{1,0,0,2});
		elements.Add(ingredientType.hammer,d_hammer);

	}

	void assignSprite(){
		GetComponent<SpriteRenderer>().sprite = d_Sprite[i_type];
        gameObject.AddComponent<BoxCollider2D>();
	}

}