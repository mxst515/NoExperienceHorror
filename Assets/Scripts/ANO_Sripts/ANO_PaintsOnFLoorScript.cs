using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANO_PaintsOnFLoorScript : MonoBehaviour
{
    [SerializeField] GameObject _mainPaints;

    void OnEnable()
    {
        _mainPaints.SetActive(false);
    }

    void OnDisable()
    {
        _mainPaints.SetActive(true);
    }

}
