using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerUp : MonoBehaviour
{
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
                    rb.AddForce(transform.forward * Speedboostforce);
                    break;

                case 2:
                    foreach (Rigidbody Playerbodies in AllPlayers)
                    {
                        if (Playerbodies != rb)
                        {
                            Playerbodies.velocity = Vector3.zero;
                        }
                    }
                    break;
            }
            
            
            pickUp.PowerUpID = 0;

            
        }
    }
}
