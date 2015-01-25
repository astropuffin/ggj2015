using UnityEngine;
using System.Collections;

public class Tool : MonoBehaviour {

    public float useTime;
    float timer;
    public bool inUse;
    public GameObject itemSpot, processingSpot;
    public s_ingredient currentIngredient;
    public Tooltip tooltip;
    public s_ingredient.toolTypes toolType;
    public GameObject particlesPrefab;
    public Sprite blenderResult, stillResult;

    public void acceptItem( s_ingredient ingredient )
    {
        currentIngredient = ingredient;
        currentIngredient.transform.parent = processingSpot.transform;
        currentIngredient.transform.localPosition = Vector3.zero;
        inUse = true;
        timer = useTime;
    }

    public virtual void processIngredient(s_ingredient ingredient)
    {
        
        var particles = Instantiate(particlesPrefab) as GameObject;
        particles.transform.position = itemSpot.transform.position;
        var elements = particles.GetComponent<ProcessedElements>();
        var elementValues = ingredient.getElements(toolType);
        //order is friendship nostaliga, laugher, fulfillment

        elements.friendship = elementValues[0];
        elements.nostalgia = elementValues[1];
        elements.laughter = elementValues[2];
        elements.fulfillment = elementValues[3];

        for(int i = 0; i < elements.friendship; i++ )
        {
            elements.colors.Add(elements.frColor);
        }
        for (int i = 0; i < elements.nostalgia; i++)
        {
            elements.colors.Add(elements.nColor);
        }
        for (int i = 0; i < elements.laughter; i++)
        {
            elements.colors.Add(elements.lColor);
        }
        for (int i = 0; i < elements.fulfillment; i++)
        {
            elements.colors.Add(elements.fuColor);
        }

        if( toolType == s_ingredient.toolTypes.blender)
        {
            particles.GetComponentInChildren<SpriteRenderer>().sprite = blenderResult;
        }
        else if ( toolType == s_ingredient.toolTypes.still)
        {
            particles.GetComponentInChildren<SpriteRenderer>().sprite = stillResult;
        }
        else if (toolType == s_ingredient.toolTypes.oven)
        {
            particles.GetComponentInChildren<SpriteRenderer>().sprite = ingredient.GetComponentInChildren<SpriteRenderer>().sprite;
            particles.GetComponentInChildren<SpriteRenderer>().color = new Color(.4f, .3f, .3f, 1);
            
        }
      
        Destroy(ingredient.gameObject);

    }

    void Update()
    {
        if(inUse)
        {
            timer -= Time.deltaTime;
            if( timer <= 0)
            {
                inUse = false;
                processIngredient(currentIngredient);

            }
        }
    }

}

