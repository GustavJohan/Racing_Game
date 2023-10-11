using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerUp : MonoBehaviour
{
    //this script is pretty self explanatory. A switch statement determine what powerup the player is holding. when the powerup button is pressed the corresponding funktion is called.
    //Using a switch statement makes the system easily expandable, simply increase the max range of the randomisation in Powerup pickup and implement a new coresponding fuction here.
    public InputActionReference PowerUpButton;

    public PowerUpPickUp pickUp;

    Rigidbody rb;

    [SerializeField]
    int Speedboostforce;

    Rigidbody[] AllPlayers;

    // Start is called before the first frame update
    void Start()
    {
        pickUp = GetComponent<PowerUpPickUp>();
        rb = GetComponent<Rigidbody>();

        AllPlayers = FindObjectsOfType<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PowerUpButton.action.ReadValue<float>() != 0 && pickUp.PowerUpID != 0)
        {
            switch (pickUp.PowerUpID)
            {
                
                case 1:
                    SpeedBoost();
                    break;


                case 2:
                    EnemySlow();
                    break;
            }
            
            
            pickUp.PowerUpID = 0;

            
        }
    }

    void SpeedBoost()
    {
        rb.AddForce(transform.forward * Speedboostforce);
    }

    void EnemySlow()
    {
        foreach (Rigidbody Playerbodies in AllPlayers)
        {
            if (Playerbodies != rb)
            {
                Playerbodies.velocity = Vector3.zero;
            }
        }
    }
}
