using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    GameObject PlayerCars;

    private void Awake()
    {
        LevelData levelData = (LevelData)Resources.Load("TestLevelData");
        ManagersUI managers = (ManagersUI)Resources.Load("UIAndManagers");


        GameObject CheckPoints = Instantiate(levelData.CheckPointsPrefab);
        GameObject Goal = Instantiate(levelData.FinishPrefab);

        if (PlayerCars == null)
        {
            PlayerCars = Instantiate(managers.SpawnPrefab);
            DontDestroyOnLoad(PlayerCars);
        }

        
        PositionTracker PosTracker = Instantiate(managers.PositionTracker).GetComponent<PositionTracker>();
        PosTracker.CheckPoints = new GameObject[CheckPoints.GetComponentsInChildren<BoxCollider>().Length];
        PosTracker.Finish = Goal.GetComponentInChildren<BoxCollider>().gameObject;

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
