using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamColorSwitch : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
         cam = GetComponent<Camera>();
         cam.backgroundColor = new Color (0, 0, 0, 1);
    }

    // Update is called once per frame
   void Update()
    {
        
        if((Input.GetKeyDown(KeyCode.Space))& cam.backgroundColor == Color.black){
            
            cam.backgroundColor = new Color (1, 1, 1, 1);
        }
        else if((Input.GetKeyDown(KeyCode.Space))& cam.backgroundColor == Color.white){
            cam.backgroundColor = new Color (0, 0, 0, 1);
           
        }
    }
}
