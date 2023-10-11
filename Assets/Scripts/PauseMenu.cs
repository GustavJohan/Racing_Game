using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public InputActionReference PauseButton;

    bool Paused;

    Button[] Menu;

    private void Start()
    {
        //getting refrences to the pause menu buttons in order to enable/disable them
        Menu = FindObjectsOfType<Button>();

        foreach (Button b in Menu)
        {
            b.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (PauseButton.action.ReadValue<float>() != 0 && Paused != true)
        {
            Pause();
        } 


    }

    void Pause()
    {
        Time.timeScale = 0.0f;
        Paused = true;

        foreach (Button b in Menu)
        {
            b.gameObject.SetActive(true);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        Paused = false;

        foreach (Button b in Menu)
        {
            b.gameObject.SetActive(false);
        }
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
