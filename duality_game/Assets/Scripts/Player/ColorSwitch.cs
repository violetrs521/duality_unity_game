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
        if((Input.GetKeyDown(KeyCode.Space))& sprite.color == Color.black)
        {
            sprite.color = Color.white;
        }

        else if((Input.GetKeyDown(KeyCode.Space))& sprite.color == Color.white)
        {
            sprite.color = Color.black;
        }
    }
}
