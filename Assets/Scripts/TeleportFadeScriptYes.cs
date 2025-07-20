using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeleportFadeScriptYes : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private RawImage fadeImageYes;

    [SerializeField] private float fadeStartDistance = 0.4f;
    [SerializeField] private float fadeMaxDistance = 1.14f;

    [SerializeField] private float fadeDuration = 1.7f;

    float distance, alpha, t;

    [Header("Debug")]
    public bool DEBUG_BOOL = false;
    [SerializeField] GameObject debugHud;
    [SerializeField] TextMeshProUGUI debugMsg1;
    [SerializeField] TextMeshProUGUI debugMsg2;

    void Start()
    {
        Vector3 playerVect = new Vector3(0,0,player.transform.position.x);
        Vector3 teleportVect = new Vector3(0,0,gameObject.transform.position.x);
        distance = Vector3.Distance(playerVect, teleportVect);

        // Zmapuj odległość do zakresu alpha
        t = Mathf.InverseLerp(fadeStartDistance, fadeMaxDistance, distance);
        alpha = Mathf.Clamp01(1f - t); // odwrotność, bo bliżej = więcej alpha
    }

    void Update()
    {
         // Pobierz obecny kolor i ustaw alpha
         SetAlpha(alpha);
        Vector3 playerVect = new Vector3(0,0,player.transform.position.x);
        Vector3 teleportVect = new Vector3(0,0,gameObject.transform.position.x);
         distance = Vector3.Distance(playerVect, teleportVect);

         // Zmapuj odległość do zakresu alpha
         t = Mathf.InverseLerp(fadeStartDistance, fadeMaxDistance, distance);
         alpha = Mathf.Clamp01(1f - t); // odwrotność, bo bliżej = więcej alpha

        
        DEBUG_CHANGE();
        DEBUG_MSG("distance: " + distance, "alpha: " + fadeImageYes.color.a);
    }

    public IEnumerator fadeCoroutineYes(){
        float elapsed = 0f;
        SetAlpha(1f);

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
        Color color = fadeImageYes.color;
        color.a = alpha;
        fadeImageYes.color = color;
    }

    public void SetFullBlackInstant()
    {
        SetAlpha(1f);
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
