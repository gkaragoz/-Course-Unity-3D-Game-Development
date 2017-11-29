using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject [] golds;

    private int score;
    public int Score
    {
        get { return score; }
        set {
            score = value;
            if (score <= 0)
                txtScore.text = "Game Over";
            else{
                SetScore();
            }
        }
    }

    private Text txtScore;

	void Start () {
        txtScore = GameObject.Find("txtScore").GetComponent<Text>();
        golds = GameObject.FindGameObjectsWithTag("Gold");
        score = golds.Length;
        SetScore();
    }

    void SetScore()
    {
        txtScore.text = "Score: " + score;
    }
}
