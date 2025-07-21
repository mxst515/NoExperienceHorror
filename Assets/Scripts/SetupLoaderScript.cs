using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupLoaderScript : MonoBehaviour
{
    [SerializeField] private PlayerLook playerLook;
    // [SerializeField] private GameObject EarlyFadeIn;

    [SerializeField] private GameObject FadeStart;
    [SerializeField] private RawImage fadeImageStart;
    [SerializeField] private float fadeDuration;
    
    void Awake()
    {
        LoadVolume();
        LoadMaxFPS();
        LoadMouseSensitivity();
    }

    void Start()
    {
        StartCoroutine(fadeCoroutineStart(fadeImageStart));
    }

    void LoadVolume()
    {
        float volume = PlayerPrefs.GetFloat("Volume", 1f);
        AudioListener.volume = volume;
    }

    void LoadMaxFPS()
    {
        QualitySettings.vSyncCount = 0;

        int[] fpsOptions = {-1, 240, 144, 60, 30}; // -1 = unlimited
        int index = PlayerPrefs.GetInt("FpsLimit", 1); // domyślnie 60 FPS (index 1)
        int targetFPS = fpsOptions[index];
        Application.targetFrameRate = targetFPS;
    }

    void LoadMouseSensitivity()
    {
        float sensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 2f);

        if (playerLook != null)
        {
            playerLook.mouseSensitivity = sensitivity;
        }
        else
        {
            Debug.LogWarning("Brak przypisanego PlayerLook w SetupLoader.");
        }
    }

    public IEnumerator fadeCoroutineStart(RawImage img){
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            SetAlpha(alpha, img);

            elapsed += Time.deltaTime;
            yield return null;
        }

        SetAlpha(0f, img); // Upewnij się że na końcu alpha to dokładnie 0

        if(FadeStart!=null){
            Destroy(FadeStart);
        }

        yield return null;
    }

    private void SetAlpha(float alpha, RawImage image)
    {
        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }

}
