using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextPrinter : MonoBehaviour {

    string sample = "You were lost in the woods. Feeling cocky after today’s swim meet, you went for what was supposed to be a relaxing stroll without bothering to so much as change out of your swim suit. It had been sunny when you left, so you were unprepared for the downpour. You were also unprepared for the rainclouds obscuring your trustworthy navigation system.";

    public float charactersPerSecond;

    public int numberOfLines;
    public int charactersPerLine;
    int charactersPerCurrentLine;

    private float stringPos = 0;
    public Text textbox;

    string currentText;

    bool waitingForInput;



    public void printScrollingString( string text )
    {
        currentText = text;
        stringPos = 0;
        var lines = new string[numberOfLines];
        int charPos = 0;
        for (int i = 0; i < numberOfLines; i++)
        {
            lines[i] = currentText.Substring(charPos, charactersPerLine);
            lines[i] = lines[i].Substring( 0, lines[i].LastIndexOf(" ") );
            charPos += lines[i].Length;
            lines[i] = lines[i].Trim();
           
        }
        StartCoroutine( printLines(lines) );
    }
    
    IEnumerator printLines( string[] lines )
    {
        var fullString = string.Join("\n", lines );
        float stringPos = 0;

        while( stringPos <= fullString.Length )
        {
            textbox.text = fullString.Substring(0, Mathf.CeilToInt(stringPos));
            stringPos += charactersPerSecond * Time.deltaTime;
            yield return null;
        }
        
    }

	// Use this for initialization
	void Start () 
    {
        printScrollingString( sample );
	}
	
	// Update is called once per frame
	void Update () 
    {
  
        
	}
}
