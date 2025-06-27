using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANO_RedLightScript : MonoBehaviour
{
    [SerializeField] private Light redLight;

    void OnEnable()
    {
        Transform child = transform.Find("RedLightTrigger");
        if(child != null){
            child.gameObject.SetActive(true);
        }
        
        redLight.intensity = 0f;
    }
}
