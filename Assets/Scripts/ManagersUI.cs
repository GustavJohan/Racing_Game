using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ManagersUI", order = 1)]
public class ManagersUI : ScriptableObject
{
    //A scriptable object containing Objects that remain constant regardless of Level
    public GameObject UIPrefab;
    public GameObject SpawnPrefab;
    public GameObject PositionTracker;
    public GameObject FirstPlaceTracker;
}
