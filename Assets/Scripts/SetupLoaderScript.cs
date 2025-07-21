using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupLoaderScript : MonoBehaviour
{
    [SerializeField] private PlayerLook playerLook;
    
    void Awake()
    {
        LoadVolume();
        LoadMaxFPS();
        LoadMouseSensitivity();
    }

    void LoadVolume()
    {
        float volume = PlayerPrefs.GetFloat("Volume", 1f);
        AudioListener.volume = volume;
    }

    void LoadMaxFPS()
    {
        int[] fpsOptions = {-1, 240, 144, 60, 30}; // -1 = unlimited
        int index = PlayerPrefs.GetInt("FpsLimit", 0); // domyślnie 60 FPS (index 1)
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
}
