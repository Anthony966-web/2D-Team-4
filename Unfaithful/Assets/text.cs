using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    string input;
    string output;
    int index;
    int timer=0;
    int delay;
    void Start()
    {
    }
    void FixedUpdate()
    {
        if (index<input.Length&&timer==0)
        {

            output += input[index];
            GetComponent<Text>().text = output;
            index++;
        }
        if(index < input.Length==false)
        {
            transform.parent.GetComponent<textbox>().MessageOver();
        }
        if (timer==0)
        {
            timer = delay;
        }
        if (timer>0)
        {

            timer -= 1;
        }
    }
    public void Write(string message,int newdelay)
    {
        output = "";
        delay = newdelay;
        input = message;
        index = 0;
    }
    public void Reset()
    {
        GetComponent<Text>().text = "";
    }
}
