using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using RenderSettings = UnityEngine.RenderSettings;
using UnityEngine.Rendering.PostProcessing;

public class dan_menuScript : MonoBehaviour
{
    public TextMeshProUGUI textForScore;
    public TextMeshProUGUI textForBiggerScore;
    public GameObject score;
    public GameObject biggerScore;
    public GameObject HowToPlay;
    public GameObject Settings;
    public TMP_Dropdown dropdown;
    public TMP_Dropdown dropdown2;

    public Material dayTimeSkyBox;
    public Material sunsetSkyBox;
    public Material nightTimeSkyBox;
    public Material mondoSkyBox;

    public Light directionLight;
    //public PostProcessVolume postProcessing;
    //private Bloom bloomSetting = null;
    //private ColorParameter colorParameter = null;
    public PostProcessVolume[] ColorVolumes;

    private Color orange = new Color(252f, 132f, 3f);
    private Color purple = new Color(190f, 3f, 252f);
    //yellow
    private Color pink = new Color(252, 3, 244);
    private Color lightBlue = new Color(3, 140, 252);

    // Start is called before the first frame update
    void Start()
    {
        directionLight.color = Color.white;
        directionLight.intensity = 1.2f;
        RenderSettings.skybox = dayTimeSkyBox;
        setVolumeColor(ColorVolumes[0]);
    }

    public void showFullScore()
    {
        textForBiggerScore.text = textForScore.text;
        score.SetActive(false);
        biggerScore.SetActive(true);
    }

    public void toggleHowToPlayMenu()
    {
        Settings.SetActive(false);
        HowToPlay.SetActive(!HowToPlay.activeInHierarchy);
    }

    public void toggleSettingsMenu()
    {
        HowToPlay.SetActive(false);
        Settings.SetActive(!Settings.activeInHierarchy);
    }

    public void updateQualitySettings()
    {
        string selectedItem = dropdown.options[dropdown.value].text;

        // Run code based on the selected item
        switch (selectedItem)
        {
            case "High Quality":
                // Code to run for Option 1
                Debug.Log("highquality");
                setQualityHigh();
                break;
            case "Medium Quality":
                setQualityMedium();
                // Code to run for Option 2
                break;
            case "Low Quality":
                setQualityLow();
                // Code to run for Option 3
                break;
            default:
                // Code to run if none of the options match
                setQualityHigh();
                break;
                
        }
    }

    public void setVolumeColor(PostProcessVolume vol)
    {
        foreach (PostProcessVolume colorVol in ColorVolumes)
        {
            if (colorVol == vol)
            {
                colorVol.enabled = true;
            }
            else
            {
                colorVol.enabled = false;
            }
        }
    }

    public void updateModeSettings()
    {
        string selectedItem = dropdown2.options[dropdown2.value].text;

        // Run code based on the selected item
        switch (selectedItem)
        {
            case "Default":

                directionLight.color = Color.white;
                directionLight.intensity = 1.2f;
                RenderSettings.skybox = dayTimeSkyBox;
                setVolumeColor(ColorVolumes[0]);

                break;
            case "Vapor Wave":

                directionLight.color = Color.magenta;
                directionLight.intensity = 1f;
                RenderSettings.skybox = mondoSkyBox;
                setVolumeColor(ColorVolumes[1]);

                break;
            case "Sunset":

                directionLight.color = Color.yellow;
                directionLight.intensity = 1f;
                RenderSettings.skybox = sunsetSkyBox;
                setVolumeColor(ColorVolumes[2]);

                break;
            case "Night":

                directionLight.color = Color.blue;
                directionLight.intensity = 0.5f;
                RenderSettings.skybox = nightTimeSkyBox;
                setVolumeColor(ColorVolumes[3]);

                break;
            default:
                // Code to run if none of the options match
                break;
        }
    }

    public void setQualityHigh()
    {
        // Set the anti-aliasing level to 8x MSAA
        QualitySettings.antiAliasing = 8;

        // Set the texture quality to high
        QualitySettings.masterTextureLimit = 0;

        // Enable anisotropic filtering and set the maximum anisotropy level to 16
        QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;

        // Set the shadow resolution to very high and enable soft shadows
        QualitySettings.shadowResolution = ShadowResolution.VeryHigh;

        // Disable VSync
        QualitySettings.vSyncCount = 0;

        // Set the resolution to 1920x1080 and the fullscreen mode to exclusive fullscreen
        Screen.SetResolution(1920, 1080, FullScreenMode.ExclusiveFullScreen);

    }

    public void setQualityMedium()
    {
        // Set the anti-aliasing level to 4x MSAA
        QualitySettings.antiAliasing = 4;

        // Set the texture quality to medium
        QualitySettings.masterTextureLimit = 1;

        // Disable anisotropic filtering
        QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;

        // Set the shadow resolution to medium and disable soft shadows
        QualitySettings.shadowResolution = ShadowResolution.Medium;

        // Enable VSync to prevent screen tearing
        QualitySettings.vSyncCount = 1;

        // Set the resolution to 1280x720 and the fullscreen mode to windowed
        Screen.SetResolution(1280, 720, FullScreenMode.Windowed);

    }

    public void setQualityLow()
    {
        // Set the anti-aliasing level to 2x MSAA
        QualitySettings.antiAliasing = 2;

        // Set the texture quality to low
        QualitySettings.masterTextureLimit = 2;

        // Disable anisotropic filtering
        QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;

        // Set the shadow resolution to low and disable soft shadows
        QualitySettings.shadowResolution = ShadowResolution.Low;

        // Disable VSync to improve performance
        QualitySettings.vSyncCount = 0;

        // Set the resolution to 800x600 and the fullscreen mode to windowed
        Screen.SetResolution(800, 600, FullScreenMode.Windowed);

    }

    // Update is called once per frame
    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
