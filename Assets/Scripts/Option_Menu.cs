using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Option_Menu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public Dropdown Button_Resolutions;

    Resolution[] resolutions;

    void Start() 
    {
        resolutions = Screen.resolutions; 

        Button_Resolutions.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
    

        Button_Resolutions.AddOptions(options);
        Button_Resolutions.value = currentResolutionIndex;
        Button_Resolutions.RefreshShownValue();

    }


    public void SetVolume (float volume)
    {

        audioMixer.SetFloat("volume", volume);
    }



    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }



    
    public void SetFullScreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }


    

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
