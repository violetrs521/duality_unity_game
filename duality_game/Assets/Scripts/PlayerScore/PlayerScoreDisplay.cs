using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Timeline;


public class PlayerScoreDisplay : MonoBehaviour
{
    public int Score { get; set; }
    public TMP_Text display;
    private Vector3 screenBounds;
    public Camera MainCamera;
    private int count;
    public TMP_Text highScoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    private void Update()
    {
        display.text = "Score: " + Score;
    }

    public void ReverseScoreColor()
    {
        display.color = display.color == Color.black ? Color.white : Color.black;
    }

    public void IncreasePoints(int amountToIncrease)
    {
        Score += amountToIncrease;
    }

    public void SetHighScore()
    {
        PersistantData.HighScore = Score > PersistantData.HighScore ? Score : PersistantData.HighScore;
        highScoreDisplay.text = "High Score: " + PersistantData.HighScore;
    }
}
