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

    

    // Start is called before the first frame update
    void Start()
    {
        Cars = FindObjectsOfType<CarPostitionTracker>();

        foreach (CarPostitionTracker p in Cars)
        {
            p.Checkpoints = gameObject.GetComponent<PositionTracker>();
        }
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Cars[0].Finished && Cars[1].Finished)
        {
            Cars[0].Finished = false;
            Cars[1].Finished = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
