using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    WheelCollider[] wheels;

    WheelCollider[] ForwardWheel;

    public InputActionReference input;

    public InputActionReference Brake;

    public Vector2 InputVector;

    Rigidbody CarBody;

    public float EngineStrength;

    public float MaxturningAngle;

    public float BrakeForce;

    // Start is called before the first frame update
    void Start()
    {
        wheels = GetComponentsInChildren<WheelCollider>();

        int i = 0;

        ForwardWheel = new WheelCollider[2];

        foreach (WheelCollider wheel in wheels)
        {
            if (wheel.name == "Wheel_Forward_Right" || wheel.name == "Wheel_Forward_Left")
            {
                ForwardWheel[i] = wheel;

                i++;
            }
        }

        CarBody = GetComponent<Rigidbody>();

        CarBody.centerOfMass = Vector3.down*0.5f;
    }

    // Update is called once per frame
    void Update()
    {
       InputVector  = input.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        foreach (WheelCollider wheel in wheels)
        {
            wheel.motorTorque = EngineStrength*InputVector.y;
            wheel.brakeTorque = BrakeForce*Brake.action.ReadValue<float>();
        }
         
        
        foreach (WheelCollider TurningWheels in ForwardWheel)
        {
            TurningWheels.steerAngle = MaxturningAngle * InputVector.x;
        }

    }
}
