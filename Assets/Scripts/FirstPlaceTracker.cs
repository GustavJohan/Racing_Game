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
    int P1Wins = 0;
    int P2Wins = 0;

    private void Start()
    {
        SceneManager.sceneLoaded += VictoryScreen;
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
        print("Scene Loaded");

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
        yield return new WaitForSeconds(5);
        P1Wins = 0;
        P2Wins = 0;
        SceneManager.LoadScene(0);
    }
}
