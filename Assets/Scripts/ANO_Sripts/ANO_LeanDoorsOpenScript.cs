using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANO_LeanDoorsOpenScript : MonoBehaviour
{
    [SerializeField] GameObject closedDoors;

    void OnTriggerEnter(Collider other)
    {
        closedDoors.SetActive(false);
        gameObject.SetActive(false);
    }
}
