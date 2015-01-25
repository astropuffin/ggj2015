using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cauldron : MonoBehaviour {

    public int currentFriendship, currentNostalgia, currentLaughter, currentFulfillment;
    public Text friendshipText, nostalgiaText, laughterText, fulfillmentText;
    public AudioClip dumpSound;
    public Formulaer formulaer;

	public void Start(){
		addElements(0,0,0,0);
	}
    public void addElements(int friendship, int nostalgia, int laughter, int fulfillment)
    {
        currentFriendship += friendship;
        friendshipText.text = ":" + currentFriendship.ToString();

        currentNostalgia += nostalgia;
        nostalgiaText.text = ":" + currentNostalgia.ToString();

        currentLaughter += laughter;
        laughterText.text = ":" + currentLaughter.ToString();

        currentFulfillment += fulfillment;
        fulfillmentText.text = ":" + currentFulfillment.ToString();

        GetComponent<RandomSounds>().playRandomSound();

        formulaer.updateIcons();


    }

    public void dump()
    {
        currentFriendship = 0; 
        friendshipText.text = ":" + currentFriendship.ToString();

        currentNostalgia = 0;
        nostalgiaText.text = ":" + currentNostalgia.ToString();

        currentLaughter = 0;
        laughterText.text = ":" + currentLaughter.ToString();

        currentFulfillment = 0;
        fulfillmentText.text = ":" + currentFulfillment.ToString();
        AudioSource.PlayClipAtPoint(dumpSound, Camera.main.transform.position);
        formulaer.updateIcons();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
