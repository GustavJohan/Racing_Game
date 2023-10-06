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

    public float Timer;

    // Start is called before the first frame update
    void Start()
    {
        //Checkpoints = FindObjectOfType<PositionTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentCheckpoint < Checkpoints.CheckPoints.Length)
        {
            Distance = (transform.position - Checkpoints.CheckPoints[CurrentCheckpoint].transform.position).magnitude;
        } else
        {
            Distance = (transform.position - Checkpoints.Finish.transform.position).magnitude;
        }
        

        if (Finished != true)
        {
            Timer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
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
        if (Laps >=   3)
        {
            Finished = true;
            print("Finished");
        }

    }

}
