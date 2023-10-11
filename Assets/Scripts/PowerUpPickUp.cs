using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickUp : MonoBehaviour
{
    //this script handles picking up and holding a value for the powerup
    public int PowerUpID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PowerUpTag")
        {
            PowerUpID = Random.Range(1, 3);
        }
    }
}
