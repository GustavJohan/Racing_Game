using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public GameObject LevelPrefab;
    public GameObject CheckPointsPrefab;
    public GameObject FinishPrefab;
}
