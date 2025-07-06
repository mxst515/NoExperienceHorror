using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANO_NoLightsScript : MonoBehaviour
{
    [SerializeField] GameObject _MainLights;

    void OnDisable()
    {
        _MainLights.SetActive(true);    
    }
}
