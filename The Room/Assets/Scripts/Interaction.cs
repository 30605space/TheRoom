using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public Text interactionText;   

    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            interactionText.text = "(E) " + other.gameObject.name; 
            if(Input.GetKeyDown(KeyCode.E) && other.gameObject.GetComponent<Animator>().GetBool("DoorOpen") == false)
            {
                Debug.Log("111111111111111111");
                other.GetComponent<Animator>().SetBool("DoorOpen", true);
            }
            if (Input.GetKeyDown(KeyCode.E) && other.gameObject.GetComponent<Animator>().GetBool("DoorOpen") == true)
            {
                other.GetComponent<Animator>().SetBool("DoorOpen", false);
            }
        }              
    }
    void OnTriggerExit(Collider other)
    {
        interactionText.text = "";
    }

}
