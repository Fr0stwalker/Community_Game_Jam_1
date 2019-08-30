using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertItem : MonoBehaviour
{
    private Item.ItemType itemInsideTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Item>())
        {
            itemInsideTrigger = other.GetComponent<Item>().itemType;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Item>())
        {
            itemInsideTrigger = Item.ItemType.None;
        }
    }
}
