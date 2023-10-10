using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ManagersUI", order = 1)]
public class ManagersUI : ScriptableObject
{
    public GameObject UIPrefab;
    public GameObject SpawnPrefab;
    public GameObject PositionTracker;
    public GameObject FirstPlaceTracker;
}
