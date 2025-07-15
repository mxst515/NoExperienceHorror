using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANO_FIreScript : MonoBehaviour
{
    [SerializeField] private GameObject FireTrigger;
    [SerializeField] private GameObject FireParticles;

    void OnEnable()
    {
        FireParticles.SetActive(false);
        FireTrigger.SetActive(true);
    }
}
