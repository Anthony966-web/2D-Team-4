using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PickAScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
