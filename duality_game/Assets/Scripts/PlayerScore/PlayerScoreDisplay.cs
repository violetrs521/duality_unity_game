using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Timeline;


public class PlayerScoreDisplay : MonoBehaviour
{
    public float score = 0;
    public TMP_Text display;
    private Vector3 screenBounds;
    public Camera MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(-(Screen.width), -(Screen.height), 0f));
        screenBounds.x += 145;
        screenBounds.y += 30;
        display.transform.position = screenBounds;
        display.text = "Time: " + score;
    }

    // Update is called once per frame
    void Update()
    { 
       score = Time.time;
       display.text = "Time: " + (int)score;

       if((Input.GetKeyDown(KeyCode.Space))& display.color == Color.black){
            
            display.color = Color.white; 
       }
       else if((Input.GetKeyDown(KeyCode.Space))& display.color == Color.white){
            
            display.color = Color.black;
       }
    }
}
