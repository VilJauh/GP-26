using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    [SerializeField]
    private WheelCollider[] wheels = new WheelCollider[4];
    [SerializeField]
    private GameObject[] wheelMesh = new GameObject[4];

    [SerializeField]
    private TMPro.TextMeshProUGUI uiText;

    [SerializeField]
    private TMPro.TextMeshProUGUI speedText;

    [SerializeField]
    private float torque = 200f;
    [SerializeField]
    private float brakeTorque = 400f;
    private float maxSteering = 30f;

    private bool reversing = false;

    private Rigidbody rb;

    private float moveInput;
    private float steerInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Drive();
        Brake();
        Steer();
    }
    private void Update()
    {
        Gear();
        GetInput();
        AnimateWheels();
        SpeedMeter();
    }
    private void Drive()
    {
        if (moveInput > 0)
        {
            foreach (var wheel in wheels)
            {
                wheel.motorTorque = moveInput * torque;
            }
        }
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.motorTorque = 0f;
            }
        }
    }
    private void Brake()
    {
        if (moveInput < 0)
        {
            foreach (var wheel in wheels)
            {
                wheel.brakeTorque = brakeTorque;
            }
        }
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.brakeTorque = 0f;
            }
        }
    }
    private void Steer() 
    {
        if (steerInput != 0)
        {
            for (int i = 0; i < wheels.Length - 2; i++)
            {
                wheels[i].steerAngle = steerInput * maxSteering;
            }
        }
        else
        {
            for (int i = 0; i < wheels.Length - 2; i++)
            {
                wheels[i].steerAngle = 0;
            }
        }
    }
    private void Gear()
    {
        if (!reversing && Input.GetKeyDown(KeyCode.R))
        { 
            reversing = true;
            torque = -torque;
            uiText.text = "R";
            return;
        }
        if (reversing && Input.GetKeyDown(KeyCode.R))
        {
            reversing = false;
            torque = -torque;
            uiText.text = "D";
            return;
        }
    }
    private void GetInput()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }
    private void SpeedMeter()
    {
        speedText.text = "Speed: " + Mathf.Ceil(rb.linearVelocity.magnitude * 2f - 1f);
    }
    private void AnimateWheels() 
    {
        Vector3 wheelPosition = Vector3.zero;
        Quaternion wheelRotation = Quaternion.identity;

        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].GetWorldPose(out wheelPosition, out wheelRotation);
            wheelMesh[i].transform.position = wheelPosition;
            wheelMesh[i].transform.rotation = wheelRotation * Quaternion.Euler(0f, 0f, 90f);
        }
    }
}
