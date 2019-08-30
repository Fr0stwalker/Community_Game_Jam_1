using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private void PickUp()
    {
        FindObjectOfType<Interaction>().hasItem = true;
        GetComponent<Rigidbody>().isKinematic = true;
        Debug.Log(transform.position);
        transform.position = Vector3.zero;
        Debug.Log(transform.position);
        transform.parent=GameObject.Find("Item In Hand").transform;
    }
}
