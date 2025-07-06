using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANO_LeanMonsterScript : MonoBehaviour
{
    [SerializeField] GameObject _monster;
    [SerializeField] Transform _monsterPos;
    [SerializeField] Transform wtr;
    [SerializeField] Transform dtr;
    [SerializeField] Transform doorClosed;
    [SerializeField] Transform doorClosedTrigger;
    [SerializeField] Transform doorOpenTrigger;

    void OnEnable()
    {
        if(wtr != null){
            wtr.gameObject.SetActive(true);
        }

        if(dtr != null){
            dtr.gameObject.SetActive(true);
        }
        
        if(doorClosed != null){
            doorClosed.gameObject.SetActive(false);
        }

        if(doorClosedTrigger != null){
            doorClosedTrigger.gameObject.SetActive(true);
        }

        if(doorOpenTrigger != null){
            doorOpenTrigger.gameObject.SetActive(true);
        }

        _monster.transform.position = _monsterPos.position; 

    }
}
