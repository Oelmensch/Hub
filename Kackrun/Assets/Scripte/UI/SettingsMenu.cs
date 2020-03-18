using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    private int screenInt;
    private float volume;
    private bool isFullscreen;

    public Slider volumeSlider;

    public Toggle fullscreenToggle;

    public AudioMixer audioMixer;

    public Dropdown qualityDropdown;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;
    Resolution resolution;

    const string prefName = "optionvalue";
    const string resName = "resolutionoption";

    private void Awake()
    {


        isFullscreen = PlayerPrefs.GetInt("Fullscreen") == 1 ? true : false;
        fullscreenToggle.isOn = isFullscreen;

        resolutionDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(resName, resolutionDropdown.value);
            PlayerPrefs.Save();
        }));

        qualityDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(prefName, qualityDropdown.value);
            PlayerPrefs.Save();
        }));

    }
    void Start()
    {
        volume = PlayerPrefs.GetFloat("Volume");
        volumeSlider.value = volume;
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);

        qualityDropdown.value = PlayerPrefs.GetInt(prefName, 3);

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentresolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height&&
               resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentresolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt(resName, currentresolutionIndex);
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        volume = volumeSlider.value;
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();        
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullsreen", ((isFullscreen) ? 1 : 0));
        PlayerPrefs.Save();
    }
}
