using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    TMP_Text[] UI;

    Image[] Powerupdisplayer;

    PowerUpPickUp[] CurrentPowerUpReader;

    PositionTracker PositionTracker;



    // Start is called before the first frame update
    void Start()
    {
        UI = new TMP_Text[2];

        int i = 0;

        foreach (TMP_Text Text in FindObjectsOfType<TMP_Text>())
        {
            
            if (Text.gameObject.tag != "PauseMenu")
            {
                
                UI[i] = Text;
                i++;
            }
        }

        PositionTracker = FindObjectOfType<PositionTracker>();

        Powerupdisplayer = new Image[2];
        
        i = 0;

        foreach (Image image in FindObjectsOfType<Image>())
        {
            if (image.gameObject.tag != "PauseMenu")
            {
                Powerupdisplayer[i] = image;
                i++;
            }
        }
            
            

        

        WaitValuesAreFound();
    }

    // Update is called once per frame
    void Update()
    {
        UI[0].text = PositionTracker.Cars[0].gameObject.name + ": " + PositionTracker.Cars[0].CurrentPosition + " Laps: " + PositionTracker.Cars[0].Laps + "/2";
        UI[1].text = PositionTracker.Cars[1].gameObject.name + ": " + PositionTracker.Cars[1].CurrentPosition + " Laps: " + PositionTracker.Cars[1].Laps + "/2";


        
        switch (CurrentPowerUpReader[0].PowerUpID)
        {
            case 0:
                Powerupdisplayer[0].color = Color.clear;
                break;
            case 1:
                Powerupdisplayer[0].color = Color.yellow; 
                break;
            case 2:
                Powerupdisplayer[0].color = Color.blue;
                break;
        }

        switch (CurrentPowerUpReader[1].PowerUpID)
        {
            case 0:
                Powerupdisplayer[1].color = Color.clear;
                break;
            case 1:
                Powerupdisplayer[1].color = Color.yellow;
                break;
            case 2:
                Powerupdisplayer[1].color = Color.blue;
                break;
        }

    }

    void SetColor()
    {
            UI[0].color = PositionTracker.Cars[0].gameObject.GetComponent<Renderer>().material.color;
            UI[1].color = PositionTracker.Cars[1].gameObject.GetComponent<Renderer>().material.color;
    }
    void WaitValuesAreFound()
    {
        CurrentPowerUpReader = new PowerUpPickUp[2];
        CurrentPowerUpReader[0] = PositionTracker.Cars[0].gameObject.GetComponent<PowerUpPickUp>();
        CurrentPowerUpReader[1] = PositionTracker.Cars[1].gameObject.GetComponent<PowerUpPickUp>();
        SetColor();
    }
}
