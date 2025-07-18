using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANO_RedLightTriggerScript : MonoBehaviour
{
    [SerializeField] Light redLight;

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("triger lights");
        StartCoroutine(redLightCoroutine());
    }

    IEnumerator redLightCoroutine(){
        redLight.intensity = 0.5f;
        yield return new WaitForSeconds(0.01f);
        redLight.intensity += 0.5f;
        yield return new WaitForSeconds(0.01f);
        redLight.intensity += 0.5f;
        yield return new WaitForSeconds(0.05f);
        redLight.intensity += 0.5f;
        yield return new WaitForSeconds(0.02f);
        redLight.intensity += 1f;
        yield return new WaitForSeconds(0.02f);
        redLight.intensity += 1f;
        yield return new WaitForSeconds(0.02f);
        redLight.intensity += 1f;
        yield return new WaitForSeconds(0.02f);
        redLight.intensity += 1f;
        yield return new WaitForSeconds(0.02f);
        redLight.intensity += 1f;
        yield return new WaitForSeconds(0.02f);
        redLight.intensity += 2f;
        yield return new WaitForSeconds(0.02f);
        gameObject.SetActive(false);
    }
}
