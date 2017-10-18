using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    [SerializeField]
    Text scoreText;
    
    public int score;

	// Use this for initialization
	void Start () {
        score = 0; //initilize score
        UpdateScore();
    }

    public void AddScore(int num)
    {
        score += num; //add up score
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = score.ToString(); //display score
        PlayerPrefs.SetInt("UpdateScore", score); //store the score to PlayerPrefs
    }
}
