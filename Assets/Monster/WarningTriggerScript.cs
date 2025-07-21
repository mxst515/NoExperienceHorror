using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningTriggerScript : MonoBehaviour
{
    [SerializeField] GameObject _monster;
    [SerializeField] Transform _monsterWarningPos;
    [SerializeField] MonsterAudio monsterAudio;

    void OnTriggerEnter(Collider other)
    {
        _monster.transform.position = _monsterWarningPos.position;
        monsterAudio.Change3dSound();
        gameObject.SetActive(false);
    }
}
