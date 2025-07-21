using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTrigger : MonoBehaviour
{
    [SerializeField] MonsterAudio monsterAudio;

    void OnTriggerEnter(Collider other)
    {
        monsterAudio.StartCoroutine(monsterAudio.DeadCoroutine());
        // gameObject.SetActive(false);
    }
}
