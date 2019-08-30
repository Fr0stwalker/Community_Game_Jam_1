using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    [SerializeField] public GameObject outline;
    public bool lookedAt;

    // Update is called once per frame
    void Update()
    {
        if (lookedAt)
        {
            outline.SetActive(true);
            Debug.Log(name+" is being looked at");
            lookedAt = false;
        }
        else
        {
            outline.SetActive(false);
        }
    }
}
