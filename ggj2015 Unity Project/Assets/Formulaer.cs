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

        for (int i = 0; i < Mathf.Max(formula[0], cauldron.currentFriendship); i++)
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
        for (int i = 0; i < Mathf.Max(cauldron.currentNostalgia, formula[1]); i++)
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

        for (int i = 0; i < Mathf.Max(cauldron.currentLaughter, formula[2]); i++)
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

        for (int i = 0; i < Mathf.Max(cauldron.currentFulfillment, formula[3]); i++)
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


}
