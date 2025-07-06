using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANO_LeanMonsterDoorScript : MonoBehaviour
{

    [SerializeField] GameObject closedDoors;

    void OnTriggerEnter(Collider other)
    {
        closedDoors.SetActive(true);
        gameObject.SetActive(false);
    }
}
