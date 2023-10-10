using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject
{ 
    //This Scriptable object contains the checkpoints and the finishline of a level.
    public GameObject CheckPointsPrefab;
    public GameObject FinishPrefab;
}
