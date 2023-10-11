using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instantiator : MonoBehaviour
{

    GameObject FirstPlaceTracker;

    private void Awake()
    {
        
        //This loads a ascriptable object that contains things that vary between levels. in this case the checkpoints and finishline
        //to easily load the prefab its name is set to the scene index for the level it belongs to
        LevelData levelData = (LevelData)Resources.Load(SceneManager.GetActiveScene().buildIndex.ToString());
        
        //This loads a scriptable object containing things that are used in every scene. in this case UI, Managers and the players
        ManagersUI managers = (ManagersUI)Resources.Load("UIAndManagers"); 
        


        
        //Since the first place tracker persistbetween scenes this segment is used to prevent duplicates of the object and getting a refrence for the First place tracker
        if (FindObjectOfType<FirstPlaceTracker>() == null)
        { 
            FirstPlaceTracker = Instantiate(managers.FirstPlaceTracker);
            DontDestroyOnLoad(FirstPlaceTracker);
        } else
        {
            FirstPlaceTracker = FindObjectOfType<FirstPlaceTracker>().gameObject;
        }
        
        GameObject CheckPoints = Instantiate(levelData.CheckPointsPrefab);
        GameObject Goal = Instantiate(levelData.FinishPrefab);

        CarPostitionTracker[] cars = Instantiate(managers.SpawnPrefab).GetComponentsInChildren<CarPostitionTracker>();
        
        // this segment instantiates the position tracker and gives it most of its necessary refrences
        PositionTracker PosTracker = Instantiate(managers.PositionTracker).GetComponent<PositionTracker>();
        PosTracker.CheckPoints = new GameObject[CheckPoints.GetComponentsInChildren<BoxCollider>().Length];
        PosTracker.Finish = Goal.GetComponentInChildren<BoxCollider>().gameObject;
        PosTracker.FirstPlace = FirstPlaceTracker.GetComponent<FirstPlaceTracker>();
        PosTracker.Cars = cars;
        
        foreach (CarPostitionTracker c in cars)
        {
            c.Checkpoints = PosTracker;
        }


        int i = 0;

        foreach (BoxCollider boxCollider in CheckPoints.GetComponentsInChildren<BoxCollider>())
        {
            PosTracker.CheckPoints[i] = boxCollider.gameObject;
            i++;
        }

        PosTracker.GetComponent<PositionTracker>().Finish = Goal.GetComponentInChildren<BoxCollider>().gameObject;
        



        Instantiate(managers.UIPrefab);
    }
}
