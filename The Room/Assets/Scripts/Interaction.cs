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
        }              
    }
    void OnTriggerExit(Collider other)
    {
        interactionText.text = "";
    }


}
