using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANO_NoLightsTrigger : MonoBehaviour
{
    [SerializeField] GameObject _MainLights;

    void OnTriggerEnter(Collider other)
    {
        _MainLights.SetActive(false);
    }
}
