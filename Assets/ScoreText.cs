using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public static int scores;
    public Text scoreText;

    void Awake()
    {
        scoreText = this.GetComponent<Text>();
        scores = 0;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    scoreText.text = "Score: " + scores;
	}
}
