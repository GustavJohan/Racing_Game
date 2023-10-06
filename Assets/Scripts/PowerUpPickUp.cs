using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickUp : MonoBehaviour
{
    public int PowerUpID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PowerUpTag")
        {
            PowerUpID = Random.Range(1, 3);
        }
    }
}
