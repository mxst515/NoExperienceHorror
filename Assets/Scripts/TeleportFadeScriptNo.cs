using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeleportFadeScriptNo : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private RawImage fadeImageNo;

    [SerializeField] private float fadeStartDistance = 0.4f;
    [SerializeField] private float fadeMaxDistance = 1.14f;

    [SerializeField] private float fadeDuration = 1.7f;

    [Header("Debug")]
    public bool DEBUG_BOOL = false;
    [SerializeField] GameObject debugHud;
    [SerializeField] TextMeshProUGUI debugMsg1;
    [SerializeField] TextMeshProUGUI debugMsg2;

    void Update()
    {
        Vector3 playerVect = new Vector3(0,0,player.transform.position.x);
        Vector3 teleportVect = new Vector3(0,0,gameObject.transform.position.x);
        float distance = Vector3.Distance(playerVect, teleportVect);

        // Zmapuj odległość do zakresu alpha
        float t = Mathf.InverseLerp(fadeStartDistance, fadeMaxDistance, distance);
        float alpha = Mathf.Clamp01(1f - t); // odwrotność, bo bliżej = więcej alpha

        // Pobierz obecny kolor i ustaw alpha
        SetAlpha(alpha);

        DEBUG_CHANGE();
        DEBUG_MSG("distance: " + distance, "alpha: " + alpha);
    }

    public IEnumerator fadeCoroutineNo(){
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            SetAlpha(alpha);

            elapsed += Time.deltaTime;
            yield return null;
        }

        SetAlpha(0f); // Upewnij się że na końcu alpha to dokładnie 0
        yield return null;
    }

    private void SetAlpha(float alpha)
    {
        Color color = fadeImageNo.color;
        color.a = alpha;
        fadeImageNo.color = color;
    }

    //DEBUG
    void DEBUG_CHANGE(){
        if(Input.GetKeyDown(KeyCode.I)){
            DEBUG_BOOL = !DEBUG_BOOL;
            debugHud.SetActive(DEBUG_BOOL);
        }
    }

    void DEBUG_MSG(string msg1, string msg2){
        debugMsg1.text = msg1;
        debugMsg2.text = msg2;
    }

}
