using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerScoreDisplay : MonoBehaviour
{
    public float score = 0;
    public TMP_Text display;

    // Start is called before the first frame update
    void Start()
    {
        display.text = "Time: " + score;
    }

    // Update is called once per frame
    void Update()
    { 
       score = Time.time;
       display.text = "Time: " + score;

       if((Input.GetKeyDown(KeyCode.Space))& display.color == Color.black){
            
            display.color = new Color(1, 1, 1, 1);
        }

        else if((Input.GetKeyDown(KeyCode.Space))& display.color == Color.white){
            
            display.color = new Color(0, 0, 0, 1);
        }
    }
}
