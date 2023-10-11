using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstPlaceTracker : MonoBehaviour
{
    // this script holds each players scores in order to determine a winner at the end. 
    int P1Wins = 0;
    int P2Wins = 0;

    private void Start()
    {
        SceneManager.sceneLoaded += VictoryScreen;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= VictoryScreen;
    }

    public void Player1Wins()
    {
        P1Wins++;
    }

    public void Player2Wins()
    {
        P2Wins++;
    }

    public void VictoryScreen(Scene scene, LoadSceneMode mode)
    {
        // every time a scene is loaded, this function checks if its the end screen.
        print("Scene Loaded");

        //if the loaded scene is the end screen this displays the winner 
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            TMP_Text Victorytext = FindObjectOfType<TMP_Text>();

            if (P1Wins < P2Wins)
            {
                Victorytext.text = "Player 1 Wins";
            }
            else
            {
                Victorytext.text = "Player 2 Wins";
            }
            StartCoroutine(WaitForAFewSeconds());
        }
    }

    IEnumerator WaitForAFewSeconds()
    {
        //this displays the winer for a few seconds before reseting itself and then reloading the first scene
        yield return new WaitForSeconds(5);
        P1Wins = 0;
        P2Wins = 0;
        SceneManager.LoadScene(0);
    }
}
