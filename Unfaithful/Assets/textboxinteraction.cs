using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textboxinteraction : MonoBehaviour
{
    // Start is called before the first frame update
    bool contact;
    string message;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)&&contact&& GetComponent<PlayerMovement>().enabled)
        {
            GetComponent<PlayerMovement>().physics();
            GameObject.FindWithTag("text box").GetComponent<textbox>().Textbox(message);
            GetComponent<PlayerMovement>().enabled = false;
            
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)&& GameObject.FindWithTag("text box").GetComponent<textbox>().MessageStatus())
        {
            GetComponent<PlayerMovement>().enabled = true;
            GameObject.FindWithTag("text box").GetComponent<textbox>().Disable();
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {

        contact = true;
        if (other.gameObject.tag == "note")
        {
            message = "I wrote this note for no reason really.";
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        contact = false;
    }
}
