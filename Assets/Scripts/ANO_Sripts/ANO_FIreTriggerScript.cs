using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANO_FIreTriggerScript : MonoBehaviour
{

    [SerializeField] GameObject fireParticles;

    void OnTriggerEnter(Collider other)
    {
        fireParticles.SetActive(true);
        gameObject.SetActive(false);
    }



}
