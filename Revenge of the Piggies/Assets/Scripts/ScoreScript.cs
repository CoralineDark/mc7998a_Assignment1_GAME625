using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0; 
    private Text score; 
    void Start()
    {
        score = GetComponent<Text>();
        scoreValue = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue + "/5";
        if (scoreValue == 5) {
            score.text = "You Won!"; 
        }
    }
}
