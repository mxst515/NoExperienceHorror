using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider mouseSlider;
    [SerializeField] private TMP_Dropdown fpsDropdown;

    void Start()
    {
        LoadSettings();

        // Listenery (jeśli chcesz reagować w czasie rzeczywistym)
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        mouseSlider.onValueChanged.AddListener(OnMouseSensitivityChanged);
        fpsDropdown.onValueChanged.AddListener(OnFpsLimitChanged);
    }

    private void LoadSettings()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        mouseSlider.value = PlayerPrefs.GetFloat("MouseSensitivity", 2f);
        fpsDropdown.value = PlayerPrefs.GetInt("FpsLimit", 1); // default np. 60 FPS

        ApplySettings();
    }

    private void ApplySettings()
    {
        AudioListener.volume = volumeSlider.value;
        // Przypisz czułość myszy do swojego systemu input
        // np. PlayerController.mouseSensitivity = mouseSlider.value;

        int[] fpsOptions = {-1, 240, 144, 60, 30}; // -1 = unlimited

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = fpsOptions[fpsDropdown.value];
    }

    public void OnVolumeChanged(float val)
    {
        PlayerPrefs.SetFloat("Volume", val);
        AudioListener.volume = val;
    }

    public void OnMouseSensitivityChanged(float val)
    {
        float rounded = Mathf.Round(val * 10f) / 10f;

        PlayerPrefs.SetFloat("MouseSensitivity", rounded);
        // np. PlayerController.mouseSensitivity = val;
    }

    public void OnFpsLimitChanged(int index)
    {
        PlayerPrefs.SetInt("FpsLimit", index);
        int[] fpsOptions = {-1, 240, 144, 60, 30};
        Application.targetFrameRate = fpsOptions[index];
    }

    public void SaveSettings()
    {
        PlayerPrefs.Save();
    }

}
