using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private bool _hasItem;
    public bool hasItem;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float range=10f;
    [SerializeField] private GameObject itemInHand;
    private void Update()
    {
        RaycastHit hit = ProcessRaycast();
        if (Input.GetButtonDown("Interact"))
        {
            if (!hasItem)
            {
                Interact(hit);
            }
            else
            {
                DropItem();
            }
        }
    }

    private void DropItem()
    {
        GameObject actualItem = itemInHand.transform.GetChild(0).gameObject;
        actualItem.transform.parent = null;
        actualItem.GetComponent<Rigidbody>().isKinematic = false;
        actualItem.GetComponent<Outline>().enabled = true;
        hasItem = false;
    }

    private void Interact(RaycastHit hit)
    {
        if (hit.transform.CompareTag("Interactive"))
        {
            hit.transform.gameObject.SendMessage("Interact");
        }
        else if (hit.transform.CompareTag("Pickable"))
        {
            hit.transform.gameObject.SendMessage("PickUp");
        }
    }

    private RaycastHit ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("Interactive") || hit.transform.CompareTag("Pickable"))
            {
                if (hit.transform.GetComponent<Outline>())
                {
                    hit.transform.GetComponent<Outline>().lookedAt = true;
                }
                Debug.Log(hit.transform.name + " was hovered over");
            }
        }

        return hit;
    }
}
