using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANO_ToyChaseTrigger : MonoBehaviour
{
    [SerializeField] ANO_ToyChaseScript toyChaseScript;

    void OnTriggerEnter(Collider other)
    {
        toyChaseScript.StartCoroutine(toyChaseScript.ChaseCoroutine());
    }
}
