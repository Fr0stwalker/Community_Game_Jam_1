using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        None,
        Key,
        Spoon,
        Fork,
        Knife
    }

    [SerializeField] public ItemType itemType;
}
