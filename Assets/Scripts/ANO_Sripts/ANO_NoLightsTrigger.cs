using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANO_NoLightsTrigger : MonoBehaviour
{
    [SerializeField] GameObject _MainLights;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip disableSound;

    void OnTriggerEnter(Collider other)
    {
        if (audioSource != null && disableSound != null)
        {
            audioSource.PlayOneShot(disableSound);
        }
        _MainLights.SetActive(false);
        gameObject.SetActive(false);
    }
}
