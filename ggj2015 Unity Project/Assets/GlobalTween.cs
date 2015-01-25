using UnityEngine;
using System.Collections;

public class GlobalTween : MonoBehaviour {

    public static GameObject tweenKing;
    public bool king;


    void Start()
    {
        if (king)
        {
            tweenKing = gameObject;
        }
    }

	// Update is called once per frame
	void Update () {
        transform.rotation = tweenKing.transform.rotation;
        transform.localScale = tweenKing.transform.localScale;
	}
}
