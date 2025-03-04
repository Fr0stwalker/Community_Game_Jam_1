﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPController : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;

    [SerializeField] private float speed=5f;
    [SerializeField] private float runningSpeed = 10f;
    [SerializeField] private float XSensitivity = 2f;
    [SerializeField] private float YSensitivity = 2f;
    private Rigidbody _rigidbody;
    private Quaternion _CharacterTargetRot;
    private Quaternion _CameraTargetRot;

    private Vector3 movement;

    private float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _rigidbody = GetComponent<Rigidbody>();
        _CharacterTargetRot = transform.localRotation;
        _CameraTargetRot = playerCamera.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runningSpeed;
        }
        else
        {
            currentSpeed = speed;
        }
        Movement();
        RotateCameraWithMouse();
        //Jumping
        //Air Control
        ChangeCursorMode();
    }

    private void RotateCameraWithMouse()
    {
        float oldYRotation = transform.eulerAngles.y;
        float yRot = Input.GetAxis("Mouse X") * XSensitivity;
        float xRot = Input.GetAxis("Mouse Y") * YSensitivity;

        _CharacterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
        _CameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);
        transform.localRotation = _CharacterTargetRot;
        playerCamera.transform.localRotation = _CameraTargetRot;
        Quaternion velRotation = Quaternion.AngleAxis(transform.eulerAngles.y - oldYRotation, Vector3.up);
        _rigidbody.velocity = velRotation * _rigidbody.velocity;

    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        movement.Set(x,0f,y);
        movement = movement.normalized * currentSpeed * Time.deltaTime;
        movement = transform.worldToLocalMatrix.inverse * movement;
        _rigidbody.MovePosition(transform.position+movement);
    }

    private static void ChangeCursorMode()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
