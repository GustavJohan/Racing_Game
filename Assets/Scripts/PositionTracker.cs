using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PositionTracker : MonoBehaviour
{
    public GameObject CheckPointsParent;

    public GameObject[] CheckPoints;

    public CarPostitionTracker[] Cars;

    public GameObject Finish;

    public FirstPlaceTracker FirstPlace;

    // Start is called before the first frame update
    void Start()
    {
        //gets refrences to the Cars positiontrackers
        Cars = FindObjectsOfType<CarPostitionTracker>();

        foreach (CarPostitionTracker p in Cars)
        {
            //Gives refrences to the car position trakers allowing them access to the checkpoint array and finishlines allowing them to track their position
            p.Checkpoints = gameObject.GetComponent<PositionTracker>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Reads and compares the values of the car position tracker and determining which car is in first place.
        if (Cars[0].CheckpointsPassed != Cars[1].CheckpointsPassed)
        {
        Cars[0].CurrentPosition = Cars[0].CheckpointsPassed > Cars[1].CheckpointsPassed ? 1 : 2;
        Cars[1].CurrentPosition = Cars[0].CheckpointsPassed < Cars[1].CheckpointsPassed ? 1 : 2;
        } 
        else
        {
            Cars[0].CurrentPosition = Cars[0].Distance < Cars[1].Distance ? 1 : 2;
            Cars[1].CurrentPosition = Cars[0].Distance > Cars[1].Distance ? 1 : 2;
        }

        //Reads if a player finishes first, gives them a point and then loads the next level
        if (Cars[0].Finished)
        {
            FirstPlace.Player1Wins();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Cars[1].Finished) 
        { 
            FirstPlace.Player2Wins();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
