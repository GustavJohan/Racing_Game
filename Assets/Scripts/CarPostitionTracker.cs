using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPostitionTracker : MonoBehaviour
{
    public float Distance;

    public PositionTracker Checkpoints;

    public int CurrentCheckpoint;

    public int CheckpointsPassed;

    public int Laps;

    public int CurrentPosition = 0;

    public bool Finished;

    // Update is called once per frame
    void Update()
    {
        //This is used to calculate the distance to the next checkpoint. This value is used by the positiontracker in order to determine the player in first place.
        if (CurrentCheckpoint < Checkpoints.CheckPoints.Length)
        {
            Distance = (transform.position - Checkpoints.CheckPoints[CurrentCheckpoint].transform.position).magnitude;
        } else
        { // the else statement is there to measure to the finishline instead of the next checkpoint when aplicable. 
            Distance = (transform.position - Checkpoints.Finish.transform.position).magnitude;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //this segement is pretty self explanatory. It determines what the next checkpoint that should be tracked is and also ensures an entire lap is completed before the player progresses
        if (CurrentCheckpoint < Checkpoints.CheckPoints.Length)
        {
            if (other.gameObject == Checkpoints.CheckPoints[CurrentCheckpoint])
            {
            CheckpointsPassed++;
            CurrentCheckpoint++;
            } 
        }
        else if (other.gameObject == Checkpoints.Finish)
        {
            CheckpointsPassed++;
            CurrentCheckpoint = 0;
            Laps++;
        }
        if (Laps >=   2)
        {
            Finished = true;
            print("Finished");
        }

    }

}
