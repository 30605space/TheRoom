using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {            
            this.GetComponent<Camera>().fieldOfView = 20f;                             
        }        
        else
        {                    
            this.GetComponent<Camera>().fieldOfView = 60f;          
        }

    }
    
}
