using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class s_ingredient : MonoBehaviour {

	public enum ingredientType {
		teddy,
		gameboy,
		hammer,
		legos,
		mushroom,
		rainbowsock,
		rubberducky,
		shoe,
		smartphone,
		helmet,
		dino,
		backpack,
		slippers
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
	public Sprite s_gameboy;
	public Sprite s_hammer;
	public Sprite s_legos;
	public Sprite s_mushroom;
	public Sprite s_rainbowsock;
	public Sprite s_rubberducky;
	public Sprite s_shoe;
	public Sprite s_smartphone;
	public Sprite s_slippers;
	public Sprite s_dino;
	public Sprite s_backback;
	public Sprite s_helment;
	
	Dictionary<ingredientType,Dictionary<toolTypes,int[]>> elements = new Dictionary<ingredientType,Dictionary<toolTypes,int[]>>();

	void Start () {
		loadSprites();
		makeRandomIngredient();
		assignSprite();
		populateData();
		loadQuips();
//		quip();
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
		d_Sprite.Add(ingredientType.gameboy,s_gameboy);
		d_Sprite.Add(ingredientType.hammer,s_hammer);
		d_Sprite.Add(ingredientType.legos,s_legos);
		d_Sprite.Add(ingredientType.mushroom, s_mushroom);
		d_Sprite.Add(ingredientType.rainbowsock,s_rainbowsock);
		d_Sprite.Add(ingredientType.rubberducky,s_rubberducky);
		d_Sprite.Add(ingredientType.shoe,s_shoe);
		d_Sprite.Add(ingredientType.smartphone,s_smartphone);
		d_Sprite.Add(ingredientType.backpack,s_backback);
		d_Sprite.Add(ingredientType.dino,s_dino);
		d_Sprite.Add(ingredientType.helmet,s_helment);
		d_Sprite.Add(ingredientType.slippers,s_slippers);
	}


	public void quip(){
		foreach (Transform child in gameObject.transform){
			TextMesh tm = child.GetComponent<TextMesh>();
			Debug.Log(i_type);
//			string[] stuff = quips[ingredientType.shoe];
			string[] quipArray = quips[i_type];
			tm.text = quipArray[UnityEngine.Random.Range(0,quipArray.Length)];
			tm.alignment = TextAlignment.Center;
            child.transform.rotation = Quaternion.identity;
			child.GetComponent<textTimer>().startClock();
			child.transform.parent = null;
		}
	}
	
	public Dictionary<ingredientType,string[]> quips = new Dictionary<ingredientType, string[]>();

	private void loadQuips(){
		quips.Add(ingredientType.teddy,new string[]{"But I love you","squeeeeeze!","You said you'd never let me go!","Don't leave me","Am I not good enough?","I can't bear to be without you!","I'm not pedobear!","This is what I get for confessing everything?!"});
		quips.Add(ingredientType.shoe,new string[]{"But I can walk 5,000 miles!","Remember when you threw me at that bully?","I already lost my partner!","I thought you said Duct tape would fix it","Can't you be persueded?","I was tied up","I shoed have seen this coming","Now I know the agony of de feet."});
		quips.Add(ingredientType.mushroom,new string[]{"Well, this is a bad trip","But I'm a fungi!","You said I was cute as a button","Oh, Shiitake!","This is immorel!","Crimeanie!","I'll find someone else to lichen me","I don't take up mush room"});
		quips.Add(ingredientType.hammer,new string[]{"I was your first weapon!","How else you gonna bang?","Where will you get your fix?","I guess that's the final nail in the coffin.","At least I'm hammered","This is not a drill! I repeat, NOT A DRILL!","Thor shall avenge me!","Stop! It's Hammer time!"});
		quips.Add(ingredientType.rubberducky,new string[]{"Fowl Play!","Well, this is going swimmingly.","Don't I fit the bill?","Hang a shirt in the shower to steam it","I'm the one","I play the best duckstep","This duck's out of luck","We still have so many songs to sing!"});
		quips.Add(ingredientType.rainbowsock,new string[]{"Taste the rainbow","I made you so cool","Sock it to me!","Lost are all the happy endings","You'll go to prism for this!","But I'm recently single","You sock!","I'm a laughingsock!"});
		quips.Add(ingredientType.gameboy,new string[]{"oh the feels","I brought you Zelda!","We gotta catch em all!","You really want to do this?","Game Over.","I'm crashing","Play Again?"});
		quips.Add(ingredientType.legos,new string[]{"I can still build your dreams!","I'm sorry about your foot","We spent so many hours together","Remember that spaceship?","This isn't what \"lego maniac\" means","I tried picking up the pieces"});
		quips.Add(ingredientType.smartphone,new string[]{"Siri said you loved me!","You were so excited about me!","You could sell me instead","What a phoney.","You're a loser without me","You said size doesn't matter!","Is there an app for that?"});
		quips.Add(ingredientType.helmet,new string[]{"Remember how I SAVED YOUR LIFE?","I convinced mom to let you ride a bike!","Clearly I didn't protect your head well enough","Now what'll keep your toupee in place?","You owe me your life!","This all goes over my head.","Hell: met.","Did you hit your head?"});
		quips.Add(ingredientType.backpack,new string[]{"I always had your back","I hid your porno mags!","I carried all your weight!","We've gone so far together!","I can pack it","Take me back!","Giving me the cold shoulder!"});
		quips.Add(ingredientType.dino,new string[]{"Is it because I can't hug you?","Rawr! Translation: I love you!","Can't you see I'm trying?","It's OK, all my friends are dead anyway.","The rest is history.","Shove it up your triassic","I'm not really a tyrant!"});
		quips.Add(ingredientType.slippers,new string[]{"You said you loved me!","I've lost that warm fuzzy feeling","What does the bunny say?","So soft... so warm","This is hare-raising.","Lettuce think about this for a moment","I'm all ears!","I'll whip my hare back and forth!"});
	}

	void populateData(){
		Dictionary<toolTypes,int[]> d_teddy = new Dictionary<toolTypes, int[]>();
		d_teddy.Add(toolTypes.blender,new int[]{1,0,0,0});
		d_teddy.Add(toolTypes.oven,new int[]{2,0,0,0});
		d_teddy.Add(toolTypes.still,new int[]{2,1,0,0});
		elements.Add(ingredientType.teddy,d_teddy);

		Dictionary<toolTypes,int[]> d_gameboy = new Dictionary<toolTypes, int[]>();
		d_gameboy.Add(toolTypes.blender,new int[]{0,0,1,0});
		d_gameboy.Add(toolTypes.oven,new int[]{0,0,2,0});
		d_gameboy.Add(toolTypes.still,new int[]{0,1,2,0});
		elements.Add(ingredientType.gameboy,d_gameboy);

		Dictionary<toolTypes,int[]> d_hammer = new Dictionary<toolTypes, int[]>();
		d_hammer.Add(toolTypes.blender,new int[]{0,0,0,1});
		d_hammer.Add(toolTypes.oven,new int[]{1,0,0,1});
		d_hammer.Add(toolTypes.still,new int[]{1,0,0,2});
		elements.Add(ingredientType.hammer,d_hammer);
		
		Dictionary<toolTypes,int[]> d_legos = new Dictionary<toolTypes, int[]>();
		d_legos.Add(toolTypes.blender,new int[]{1,0,0,0});
		d_legos.Add(toolTypes.oven,new int[]{2,1,0,0});
		d_legos.Add(toolTypes.still,new int[]{2,2,0,0});
		elements.Add(ingredientType.legos,d_legos);

		Dictionary<toolTypes,int[]> d_mushroom = new Dictionary<toolTypes, int[]>();
		d_mushroom.Add(toolTypes.blender,new int[]{0,0,1,0});
		d_mushroom.Add(toolTypes.oven,new int[]{0,0,2,0});
		d_mushroom.Add(toolTypes.still,new int[]{0,0,2,1});
		elements.Add(ingredientType.mushroom,d_mushroom);

		Dictionary<toolTypes,int[]> d_rainbowsock = new Dictionary<toolTypes, int[]>();
		d_rainbowsock.Add(toolTypes.blender,new int[]{0,1,1,0});
		d_rainbowsock.Add(toolTypes.oven,new int[]{1,1,1,1});
		d_rainbowsock.Add(toolTypes.still,new int[]{2,2,2,2});
		elements.Add(ingredientType.rainbowsock,d_rainbowsock);
		
		Dictionary<toolTypes,int[]> d_rubberducky = new Dictionary<toolTypes, int[]>();
		d_rubberducky.Add(toolTypes.blender,new int[]{0,1,0,0});
		d_rubberducky.Add(toolTypes.oven,new int[]{1,1,0,0});
		d_rubberducky.Add(toolTypes.still,new int[]{1,3,0,0});
		elements.Add(ingredientType.rubberducky,d_rubberducky);

		Dictionary<toolTypes,int[]> d_shoe = new Dictionary<toolTypes, int[]>();
		d_shoe.Add(toolTypes.blender,new int[]{0,0,0,1});
		d_shoe.Add(toolTypes.oven,new int[]{0,0,0,2});
		d_shoe.Add(toolTypes.still,new int[]{1,0,0,2});
		elements.Add(ingredientType.shoe,d_shoe);

		Dictionary<toolTypes,int[]> d_smartphone = new Dictionary<toolTypes, int[]>();
		d_smartphone.Add(toolTypes.blender,new int[]{1,0,0,0});
		d_smartphone.Add(toolTypes.oven,new int[]{1,0,0,1});
		d_smartphone.Add(toolTypes.still,new int[]{1,0,0,2});
		elements.Add(ingredientType.smartphone,d_smartphone);
		
		Dictionary<toolTypes,int[]> d_dino = new Dictionary<toolTypes, int[]>();
		d_dino.Add(toolTypes.blender,new int[]{0,0,1,0});
		d_dino.Add(toolTypes.oven,new int[]{1,0,1,0});
		d_dino.Add(toolTypes.still,new int[]{1,0,2,0});
		elements.Add(ingredientType.dino,d_dino);

		Dictionary<toolTypes,int[]> d_slippers = new Dictionary<toolTypes, int[]>();
		d_slippers.Add(toolTypes.blender,new int[]{0,1,0,0});
		d_slippers.Add(toolTypes.oven,new int[]{0,1,0,1});
		d_slippers.Add(toolTypes.still,new int[]{1,1,0,1});
		elements.Add(ingredientType.slippers,d_slippers);

		Dictionary<toolTypes,int[]> d_backpack = new Dictionary<toolTypes, int[]>();
		d_backpack.Add(toolTypes.blender,new int[]{0,1,0,0});
		d_backpack.Add(toolTypes.oven,new int[]{0,1,0,1});
		d_backpack.Add(toolTypes.still,new int[]{0,2,0,1});
		elements.Add(ingredientType.backpack,d_backpack);

		Dictionary<toolTypes,int[]> d_helmet = new Dictionary<toolTypes, int[]>();
		d_helmet.Add(toolTypes.blender,new int[]{0,1,0,0});
		d_helmet.Add(toolTypes.oven,new int[]{1,0,1,0});
		d_helmet.Add(toolTypes.still,new int[]{1,0,1,1});
		elements.Add(ingredientType.helmet,d_helmet);
	}

	void assignSprite(){
		GetComponent<SpriteRenderer>().sprite = d_Sprite[i_type];
        gameObject.AddComponent<BoxCollider2D>();
	}

}