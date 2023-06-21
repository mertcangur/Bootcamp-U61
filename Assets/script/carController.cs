using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class carController : MonoBehaviour
{
    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public GameObject wheelEffectObj;
        public Axel axel;
    }

    public float maxAcceleration = 30f;
    public float breakAcceleration = 50f;

    public float turnSensivity = 1.0f;
    public float maxSteerAngle = 30f;

    //public Vector3 _centerOfMass;


    public List<Wheel> wheels;

    float moveInput;
    float steerInput;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(rb.centerOfMass.x, rb.centerOfMass.y - 1f, rb.centerOfMass.z);
    }

    private void Update()
    {
        GetInputs();
        Animatewheels();
        WheelEffects();
    }
    void LateUpdate()
    {
        Move();
        Steer();
        Brake();
    }
    void GetInputs()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }

    private void Move()
    {
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = -moveInput * 800 * maxAcceleration * Time.deltaTime;
             
        }
    }
    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if(wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }

    void Brake()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 300  * breakAcceleration * Time.deltaTime;

            }
        }
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }
        }
    }
    void Animatewheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot; 
        }
    }
    void WheelEffects()
    {
        foreach (var wheel in wheels)
        {
            if(Input.GetKey(KeyCode.Space)&& wheel.axel == Axel.Rear )
            {
                wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = true;
            }
            else
                wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = false;

        }
    }
}
