using UnityEngine;
using System.Collections;

public class GlobalTween : MonoBehaviour {

    public static GameObject tweenKing;
    public bool additive;
    public bool king;
    Quaternion initialRotation;

    void Start()
    {
        if (king)
        {
            tweenKing = gameObject;
        }
        if(additive)
        {
            initialRotation = transform.rotation;
        }
    }

	// Update is called once per frame
	void Update () {
        if(!additive)
        {
            transform.rotation = tweenKing.transform.rotation;
            transform.localScale = tweenKing.transform.localScale;
        }
        else
        {
            transform.rotation =  initialRotation * tweenKing.transform.rotation;
            transform.localScale = tweenKing.transform.localScale;
        }
	}
}
