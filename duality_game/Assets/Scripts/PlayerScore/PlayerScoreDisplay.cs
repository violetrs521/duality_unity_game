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

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(-(Screen.width), -(Screen.height), 0f));
        screenBounds.x += 800;
        screenBounds.y += 80;
        display.fontSize = 80f;
        display.transform.position = screenBounds;
        display.text = "Score: " + Score;
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
}
