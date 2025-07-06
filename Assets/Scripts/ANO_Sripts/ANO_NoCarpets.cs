using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANO_NoCarpets : MonoBehaviour
{
    [SerializeField] GameObject _MainCarpets;

    void OnEnable()
    {
        _MainCarpets.SetActive(false);
    }

    void OnDisable()
    {
        _MainCarpets.SetActive(true);
    }
}
