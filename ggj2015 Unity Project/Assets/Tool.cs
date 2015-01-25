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
        Debug.Log("processed!");
        currentIngredient.transform.parent = itemSpot.transform;
        currentIngredient.transform.localPosition = Vector3.zero;
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

