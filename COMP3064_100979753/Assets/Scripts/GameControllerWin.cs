using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerWin : MonoBehaviour {
    [SerializeField]
    Text highScoreText;

    int highscore;
    // Use this for initialization
    void Start () {
        highscore = PlayerPrefs.GetInt("UpdateScore"); //get the score from PlayerPrefs
        highScoreText.text = "HIGH SCORE: " + highscore; //display high score
	}
}
