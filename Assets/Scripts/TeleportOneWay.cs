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
             Teleport(other);
         }
    }

    private void Interact()
    {
        Teleport(FindObjectOfType<FPController>().GetComponent<Collider>());
    }

    private void Teleport(Collider other)
    {
        other.transform.position = teleportExit.position;
    }
}
