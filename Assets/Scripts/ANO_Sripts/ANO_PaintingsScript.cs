using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANO_PaintingsScript : MonoBehaviour
{

    [SerializeField] GameObject _MainWallPaints;

    void OnEnable()
    {
        Debug.Log("paintings");
        _MainWallPaints.SetActive(false);
    }

    void OnDisable()
    {
        _MainWallPaints.SetActive(true);
    }
}
