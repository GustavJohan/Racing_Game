using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ // Very simple script for a main menu
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }


    public void Quit()
    {
        Application.Quit();
    }
}
