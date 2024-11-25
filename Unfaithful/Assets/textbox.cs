using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textbox : MonoBehaviour
{
    public RawImage looks;
    bool messageover = false;
    // Start is called before the first frame update
    void Start()
    {
        looks.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Textbox(string message)
    {
        looks.enabled = true;
        transform.GetChild(0).GetComponent<text>().Write(message, 5);
        messageover = false;
    }
    public void MessageOver()
    {
        messageover = true;
    }
    public bool MessageStatus()
    {
        return messageover;
    }
    public void Disable()
    {
        looks.enabled = false;
        transform.GetChild(0).GetComponent<text>().Reset();
    }
}
