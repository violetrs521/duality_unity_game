using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sprite;
    
    
    void Start()
    {
       
       
        
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space))& sprite.color == Color.black){
            
            sprite.color = new Color(1, 1, 1, 1);
        }

        else if((Input.GetKeyDown(KeyCode.Space))& sprite.color == Color.white){
            
            sprite.color = new Color(0, 0, 0, 1);
        }
    }
}
