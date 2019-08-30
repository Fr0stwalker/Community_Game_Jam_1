using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    enum ItemType
    {
        Key,
        Spoon,
        Fork,
        Knife
    }

    [SerializeField] private ItemType itemType;
}
