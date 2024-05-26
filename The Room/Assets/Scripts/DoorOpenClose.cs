using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    bool isdoorOpen = false;
    bool inrange = false;

    Animator dranim;

    void Start()
    {
        dranim = GetComponent<Animator>();
    }
    
    // Hitbox Enter
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Hit"))
        {
            inrange = true;
        }
    }

    // Hitbox Exit
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Hit"))
        {
            inrange = false;
        }
    }

    // PRESS E
    void Update()
    {
        if(inrange == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {

                if(isdoorOpen == false) 
                {
                    dranim.SetTrigger("DoorOpen");
                    isdoorOpen = true;
                }

                else
                {
                    dranim.SetTrigger("DoorClose");
                    isdoorOpen = false;
                }

            }
        }
    }
}
