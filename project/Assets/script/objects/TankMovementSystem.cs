using UnityEngine;
using System.Collections;

public class TankMovementSystem : MovementSystem
{
    //Wheels are used as raytraces to detect the ground, there not used for movement
    public Wheel[] leftWheels;
    public Wheel[] rightWheels;

    public Rigidbody body;

    public WheelCollider wheelToPullValuesFrom;

    protected float wheelRenderRotation;

    public float lastMovementPower = 0;
    public float lastTurnPower = 0;

    public float leftPower = 0;
    public float rightPower = 0;

    protected override void InitValues()
    {
        SetValues(leftWheels);
        SetValues(rightWheels);
    }

    //Update wheel values to match prefab
    protected void SetValues(Wheel[] wheels)
    {
        foreach (Wheel wheel in wheels)
        {
            wheel.wheelCollider.mass = wheelToPullValuesFrom.mass;
            wheel.wheelCollider.radius = wheelToPullValuesFrom.radius;
            wheel.wheelCollider.wheelDampingRate = wheelToPullValuesFrom.wheelDampingRate;
            wheel.wheelCollider.suspensionDistance = wheelToPullValuesFrom.suspensionDistance;
            wheel.wheelCollider.forceAppPointDistance = wheelToPullValuesFrom.forceAppPointDistance;
            wheel.wheelCollider.center = wheelToPullValuesFrom.center;
            wheel.wheelCollider.suspensionSpring = wheelToPullValuesFrom.suspensionSpring;
            wheel.wheelCollider.forwardFriction = wheelToPullValuesFrom.forwardFriction;
            wheel.wheelCollider.sidewaysFriction = wheelToPullValuesFrom.sidewaysFriction;
        }
    }

    //Called to move wheels
    protected override void DoMovement()
    {
        Vector3 movement = transform.forward * movementRatio * movementPower * Time.deltaTime;
        body.MovePosition(body.position + movement);

        float turn = turnRatio * rotationPower * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        body.MoveRotation(body.rotation * turnRotation);
    }

    protected override void UpdateWheelVisuals()
    {
        //Update rotation, this is temp for testing
        wheelRenderRotation += 1;
        if (wheelRenderRotation > 360)
        {
            wheelRenderRotation = 0;
        }
        //TODO calculate rotation speed based on movement speed of each track independently 

        UpdateWheelVisuals(leftWheels);
        UpdateWheelVisuals(rightWheels);
    }


    private void UpdateWheelVisuals(Wheel[] wheels)
    {
        //Update wheels
        foreach (Wheel wheel in wheels)
        {
            Vector3 position;
            Quaternion r;
            wheel.wheelCollider.GetWorldPose(out position, out r);

            wheel.visualWheel.transform.position = position;
            wheel.visualWheel.transform.rotation.Set(0, 0, wheelRenderRotation, 0); //TODO only capture axis rotation ignoring tilt
        }
    }

    private void UpdateMovement(Wheel[] wheels, float power)
    {
        //Disable movement on wheels
        foreach (Wheel wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = 0;
        }
    }
}
