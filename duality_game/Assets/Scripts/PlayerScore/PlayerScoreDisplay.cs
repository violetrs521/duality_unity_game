using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Timeline;


public class PlayerScoreDisplay : MonoBehaviour
{
    public int score = 0;
    public TMP_Text display;
    private Vector3 screenBounds;
    public Camera MainCamera;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(-(Screen.width), -(Screen.height), 0f));
        screenBounds.x += 800;
        screenBounds.y += 80;
        display.fontSize = 80f;
        display.transform.position = screenBounds;
        display.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if (count % 30 == 0)
        {
            score += 1;
        }
        display.text = "Score: " + score;
       

       if((Input.GetKeyDown(KeyCode.Space))& display.color == Color.black){
            
            display.color = Color.white; 
       }
       else if((Input.GetKeyDown(KeyCode.Space))& display.color == Color.white){
            
            display.color = Color.black;
       }
    }
}
