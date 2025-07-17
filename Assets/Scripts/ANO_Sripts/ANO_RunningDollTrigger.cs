using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANO_RunningDollTrigger : MonoBehaviour
{
    [SerializeField] ANO_RunningDollScript doll_script;

    void OnTriggerEnter(Collider other)
    {
        doll_script.StartCoroutine(doll_script.runCouroutine());
    }
}
