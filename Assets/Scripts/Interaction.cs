using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float range=10f;
    private void Update()
    {
        ProcessRaycast();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("Interactive"))
            {
                Debug.Log(hit.transform.name + " was hovered over");
            }
        }
    }
}
