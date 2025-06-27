using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningTriggerScript : MonoBehaviour
{
    [SerializeField] GameObject _monster;
    [SerializeField] Transform _monsterWarningPos;

    void OnTriggerEnter(Collider other)
    {
        _monster.transform.position = _monsterWarningPos.position;
        gameObject.SetActive(false);
    }
}
