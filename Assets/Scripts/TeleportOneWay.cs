using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOneWay : MonoBehaviour
{
    [SerializeField] private Transform teleportExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FPController>())
        {
            other.transform.position = teleportExit.position;
        }
    }
}
