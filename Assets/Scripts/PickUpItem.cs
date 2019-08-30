using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private void PickUp()
    {
        FindObjectOfType<Interaction>().hasItem = true;
        GetComponent<Rigidbody>().isKinematic = true;
        transform.parent=GameObject.Find("Item In Hand").transform;
        transform.localPosition=Vector3.zero;
        transform.localRotation=Quaternion.Euler(0,90f,90f);
        GetComponent<Outline>().enabled = false;
        GetComponent<Outline>().outline.SetActive(false);
    }
}
