using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Formulaer : MonoBehaviour {
  
    //friend, nost, laugh, full
    public GameObject gridGuy;

    public GameObject frIcon, nIcon, lIcon, fuIcon, cross;
    public Cauldron cauldron;
    public int[] formula = new int[] {1, 2, 0, 1};
    public AudioClip winSound;
    public int difficulty;
    public Text potionText, scoreText;
    public int score = -1;

    void Start()
    {
        formulate();
        updateIcons();
    }

    public void updateIcons()
    {
        foreach (Transform item in gridGuy.transform)
        {
            Destroy(item.gameObject);
        }

        int cauldronFriendship = cauldron.currentFriendship;
        if (formula[0] == 0)
            cauldronFriendship = 0;

        for (int i = 0; i < Mathf.Max(formula[0], cauldronFriendship); i++)
        {
            var icon = Instantiate(frIcon) as GameObject;
            icon.transform.SetParent(gridGuy.transform);


            if (cauldronFriendship > formula[0])
            {
                var crossObj = Instantiate(cross) as GameObject;
                crossObj.transform.SetParent(icon.transform);
                crossObj.transform.localPosition = Vector3.zero;
                cauldronFriendship--;
            }
            else if (cauldronFriendship > 0)
            {
                var color = icon.GetComponent<Image>().color;
                color.a = 1;
                icon.GetComponent<Image>().color = color;
                cauldronFriendship--;
            }
            else
            {
                var color = icon.GetComponent<Image>().color;
                color.a = .5f;
                icon.GetComponent<Image>().color = color;
            }
        }
        
        //nostalgia
        int cauldronNostalgia = cauldron.currentNostalgia;
        if (formula[1] == 0)
            cauldronNostalgia = 0;
        for (int i = 0; i < Mathf.Max(cauldronNostalgia, formula[1]); i++)
        {
            var icon = Instantiate(nIcon) as GameObject;
            icon.transform.SetParent(gridGuy.transform);

            if (cauldronNostalgia > formula[1])
            {
                var crossObj = Instantiate(cross) as GameObject;
                crossObj.transform.SetParent(icon.transform);
                crossObj.transform.localPosition = Vector3.zero;
                cauldronNostalgia--;
            }
            else if (cauldronNostalgia > 0)
            {
                var color = icon.GetComponent<Image>().color;
                color.a = 1;
                icon.GetComponent<Image>().color = color;
                cauldronNostalgia--;
            }
            else
            {
                var color = icon.GetComponent<Image>().color;
                color.a = .5f;
                icon.GetComponent<Image>().color = color;
            }

        }

        //laughter
        int cauldronLaughter = cauldron.currentLaughter;
        if (formula[2] == 0)
            cauldronLaughter = 0;

        for (int i = 0; i < Mathf.Max(cauldronLaughter, formula[2]); i++)
        {
            var icon = Instantiate(lIcon) as GameObject;
            icon.transform.SetParent(gridGuy.transform);

            if (cauldronLaughter > formula[2])
            {
                var crossObj = Instantiate(cross) as GameObject;
                crossObj.transform.SetParent(icon.transform);
                crossObj.transform.localPosition = Vector3.zero;
                cauldronLaughter--;
            }
            else if (cauldronLaughter > 0)
            {
                var color = icon.GetComponent<Image>().color;
                color.a = 1;
                icon.GetComponent<Image>().color = color;
                cauldronLaughter--;
            }
            else
            {
                var color = icon.GetComponent<Image>().color;
                color.a = .5f;
                icon.GetComponent<Image>().color = color;
            }

        }

        //fulfillment
        int cauldronFulfillment = cauldron.currentFulfillment;
        if (formula[3] == 0)
            cauldronFulfillment = 0;

        for (int i = 0; i < Mathf.Max(cauldronFulfillment, formula[3]); i++)
        {
            var icon = Instantiate(fuIcon) as GameObject;
            icon.transform.SetParent(gridGuy.transform);

            if (cauldronFulfillment > formula[3])
            {
                var crossObj = Instantiate(cross) as GameObject;
                crossObj.transform.SetParent(icon.transform);
                crossObj.transform.localPosition = Vector3.zero;
                cauldronFulfillment--;
            }
            else if (cauldronFulfillment > 0)
            {
                var color = icon.GetComponent<Image>().color;
                color.a = 1;
                icon.GetComponent<Image>().color = color;
                cauldronFulfillment--;
            }
            else
            {
                var color = icon.GetComponent<Image>().color;
                color.a = .5f;
                icon.GetComponent<Image>().color = color;
            }

        }

    }

    public void formulate()
    {
        for (int i = 0; i < formula.Length; i++)
        {
            formula[i] = Random.Range(0, difficulty);
        }
        cauldron.dump();
        potionText.text = "Recipe:\n" + potionNames[Random.Range(0, potionNames.Length)];
        score++;
        scoreText.text = "Potions made: " + score.ToString();

        updateIcons();
      
    }


    public void achieve()
    {
        //friend, nost, laugh, full
        int fr = formula[0];
        int n = formula[1];
        int l = formula[2];
        int fu = formula[3];

        bool validFr = false;
        if (fr > 0 && fr == cauldron.currentFriendship)
        {
            validFr = true;
        }
        else if ( fr == 0 )
        {
            validFr = true;
        }
        else
        {
            validFr = false;
        }

        bool validN = false;
        if (n > 0 && n == cauldron.currentNostalgia)
        {
            validN = true;
        }
        else if (n == 0)
        {
            validN = true;
        }
        else
        {
            validN = false;
        }


        bool validL = true;
        if (l > 0 && l == cauldron.currentLaughter)
        {
            validL = true;
        }
        else if (l == 0)
        {
            validL = true;
        }
        else
        {
            validL = false;
        }


        bool validFu = true;
        if (fu > 0 && fu == cauldron.currentFulfillment)
        {
            validFu = true;
        }
        else if (fu == 0)
        {
            validFu = true;
        }
        else
        {
            validFu = false;
        }
        
        
       if( validFr && validFu && validL && validN)
       {
           AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position);
           formulate();

       }

    }


    string[] potionNames = new string[]{
			"Potion of Cromulence",
			"Potion of Dastardly Delight",
			"Potion of Modest Mugwumps",
			"Potion of Bucket",
			"Potion of Godwottery",
			"Potion of Cleared Collywobbles",
			"Potion of Biggification",
			"Potion of Poopy Poop",
			"Potion of Unremacadamization",
			"Potion of Batrachomyomachy",
			"Potion of Callipygian Cohorts",
			"Potion of Logorrhea",
			"Potion of Formication",
			"Potion of Tort",
			"Potion of Namicone",
			"Potion of Bees!",
			"Potion of Absquatulation",
			"Potion of Anencephalous Enemies",
			"Potion of Hemidemisemiquaver",
			"Potion of Snools",
			"Potion of Walking Widdershins",
			"Potion of Pleasing Pandiculation",
			"Potion of Cherry Poppin'",
			"Potion of Gainful Gastromancy",
			"Potion of Doge",
			"Such Potion",
			"Potion of Mumpsimus",
			"Potion of Getting Your Friends Back",
			"Potion of Makeup Sex",
			"Potion of Bacon",
			"Potion of Internet Fame",
			"Potion of Polyglottery",
			"Potion of Catching Pokemon",
			"Potion of Cleaning All The Things",
			"Potion of Pwning Newbs",
			"Potion of Turning Gay",
			"Potion of Thor",
			"Potion of Mermaidery",
			"Potion of Potion Making",
			"Potion of Looking Cool In A Trilby",
			"Potion of Ethics in Games Journalism",
			"Potion of Turdiformity",
			"Potion of Humorous Hashtags",
			"Potion of @%$!",
			"Potion of Emphatic Eructation",
			"Potion of Frikin' Firkins",
			"Potion of Backpfeifengesicht",
			"Potion of Moist Wenises",
			"Potion of Floccinaucinihilipilification",
			"Potion of Heart Tittles",
			"Potion of 6.39509382",
			"Potion of Spoonerisms",
			"Potion of Apivorous Birds",
			"Potion of Ensorcelling",
			"Potion of Understanding Ikea Names",
			"Potion of Sanitizing Smegma",
			"Potion of Battle Rapping",
			"Potion of Becoming Whelmed",
			"Potion of Nyan Nyan Nyan Nyan Nyan Nyan Nyan",
			"Potion of Pogonotrophy",
		};

}
