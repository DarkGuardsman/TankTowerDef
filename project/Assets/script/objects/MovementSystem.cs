using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class MovementSystem : MonoBehaviour
{
    public float movementPower;
    public float rotationPower;

    //Movement value -1 and 1f
    [SerializeField]
    protected float movementRatio;

    //Turn speed value -1 and 1f
    [SerializeField]
    protected float turnRatio;

    //Called to move wheels
    protected virtual void DoMovement()
    {
        //Apply movement to colliders
    }

    protected virtual void UpdateWheelVisuals()
    {
        //Update wheel visuals (aka move wheels up and down, do rotation)
    }

    protected virtual void InitValues()
    {

    }

    public void Start()
    {
        InitValues();
    }

    public void FixedUpdate()
    {
        DoMovement();
    }

    public void Update()
    {
        UpdateWheelVisuals();
    }

    public void SetMovementRatio(float value)
    {
        this.movementRatio = value;
    }

    public void SetTurnRatio(float value)
    {
        this.turnRatio = value;
    }
}
