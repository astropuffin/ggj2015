using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour {


    public Text timer, youWin;
    public float time = 5;
    public Formulaer fomrulaer;
	// Use this for initialization
    public s_conveyor conveyor;
	
    

	// Update is called once per frame
	void Update () {
        if( time <= 0 )
        {
            conveyor.enabled = false;
            youWin.gameObject.SetActive(true);
            youWin.text = "YOU MADE " + fomrulaer.score.ToString() + " POTIONS!\n Was it worth it?";
        }
        else
        {
            time -= Time.deltaTime;
            timer.text = "Time Remaining\n" + ((int)time).ToString();
            
        }
	}
}
