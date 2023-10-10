using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instantiator : MonoBehaviour
{
    GameObject PlayerCars;

    GameObject FirstPlaceTracker;

    private void Awake()
    {
        LevelData levelData = (LevelData)Resources.Load(SceneManager.GetActiveScene().buildIndex.ToString());
        ManagersUI managers = (ManagersUI)Resources.Load("UIAndManagers");


        GameObject CheckPoints = Instantiate(levelData.CheckPointsPrefab);
        GameObject Goal = Instantiate(levelData.FinishPrefab);

        PlayerCars = Instantiate(managers.SpawnPrefab);

        if (FindObjectOfType<FirstPlaceTracker>() == null)
        {
            FirstPlaceTracker = Instantiate(managers.FirstPlaceTracker);
            DontDestroyOnLoad(FirstPlaceTracker);
        } else
        {
            FirstPlaceTracker = FindObjectOfType<FirstPlaceTracker>().gameObject;
        }

        
        
        PositionTracker PosTracker = Instantiate(managers.PositionTracker).GetComponent<PositionTracker>();
        PosTracker.CheckPoints = new GameObject[CheckPoints.GetComponentsInChildren<BoxCollider>().Length];
        PosTracker.Finish = Goal.GetComponentInChildren<BoxCollider>().gameObject;
        PosTracker.FirstPlace = FirstPlaceTracker.GetComponent<FirstPlaceTracker>();

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
