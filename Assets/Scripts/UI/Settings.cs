using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class Settings : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject SettingsMenu;
    [SerializeField] AudioMixer Mixer;
    [SerializeField] List<GameObject> BarsMusic;
    [SerializeField] List<GameObject> BarsSound;
    [SerializeField] TextMeshProUGUI ResText;

    int MusicVolumeStep = 5;
    int SoundVolumeStep = 5;

    private int currentResolutionIndex = 0;
    Vector2Int res;
    int ResIndex = 3;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetInt("Music", 5);
            PlayerPrefs.SetInt("Sound", 5);
        }

        MusicVolumeStep = PlayerPrefs.GetInt("Music");
        SoundVolumeStep = PlayerPrefs.GetInt("Sound");

        float musicDb = Mathf.Lerp(-50f, 15f, MusicVolumeStep / 10f);
        float soundDb = Mathf.Lerp(-50f, 15f, SoundVolumeStep / 10f);

        Mixer.SetFloat("MusicVolume", musicDb);
        Mixer.SetFloat("EffectVolume", soundDb);

        SetBars("Music");
        SetBars("Sound");

        if (!PlayerPrefs.HasKey("Res"))
        {
            PlayerPrefs.SetInt("Res", ResIndex);
        }

        ResIndex = PlayerPrefs.GetInt("Res");

        SetResolutionByIndex();
    }

    public void AddMusic()
    {
        MusicVolumeStep = Mathf.Clamp(MusicVolumeStep + 1, 0, 10);

        float dB = Mathf.Lerp(-50f, 15f, MusicVolumeStep / 10f);
        Mixer.SetFloat("MusicVolume", dB);
        PlayerPrefs.SetInt("Music", MusicVolumeStep);

        SetBars("Music");
    }

    public void RemoveMusic()
    {
        MusicVolumeStep = Mathf.Clamp(MusicVolumeStep - 1, 0, 10);

        float dB = Mathf.Lerp(-50f, 15f, MusicVolumeStep / 10f);
        Mixer.SetFloat("MusicVolume", dB);
        PlayerPrefs.SetInt("Music", MusicVolumeStep);

        SetBars("Music");
    }

    public void AddSound()
    {
        SoundVolumeStep = Mathf.Clamp(SoundVolumeStep + 1, 0, 10);

        float dB = Mathf.Lerp(-50f, 15f, SoundVolumeStep / 10f);
        Mixer.SetFloat("EffectVolume", dB);
        PlayerPrefs.SetInt("Sound", SoundVolumeStep);

        SetBars("Sound");
    }

    public void RemoveSound()
    {
        SoundVolumeStep = Mathf.Clamp(SoundVolumeStep - 1, 0, 10);

        float dB = Mathf.Lerp(-50f, 15f, SoundVolumeStep / 10f);
        Mixer.SetFloat("EffectVolume", dB);
        PlayerPrefs.SetInt("Sound", SoundVolumeStep);

        SetBars("Sound");
    }

    public void SetBars(string VolumeType)
    {
        int n = PlayerPrefs.GetInt(VolumeType);
        int counter = 0;

        if (VolumeType == "Music")
        {
            foreach (var Bar in BarsMusic)
            {
                counter++;

                if (counter <= n)
                {
                    Bar.SetActive(true);
                }
                else
                {
                    Bar.SetActive(false);
                }
            }
        }
        else
        {
            foreach (var Bar in BarsSound)
            {
                counter++;

                if (counter <= n)
                {
                    Bar.SetActive(true);
                }
                else
                {
                    Bar.SetActive(false);
                }
            }
        }

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
    }

    private List<Vector2Int> popularResolutions = new List<Vector2Int>()
    {
        // Standard resolutions
        new Vector2Int(1280, 720),    // HD
        new Vector2Int(1366, 768),    // WXGA
        new Vector2Int(1600, 900),    // HD+
        new Vector2Int(1920, 1080),   // Full HD
        new Vector2Int(2560, 1080),   // Ultrawide Full HD (21:9)
        new Vector2Int(2560, 1440),   // QHD
        new Vector2Int(3440, 1440),   // Ultrawide QHD (21:9)
        new Vector2Int(3840, 1600),   // UW 3840x1600 (21:9)
        new Vector2Int(3840, 2160),   // 4K UHD
    };

    public void AddRes()
    {
        ResIndex++;

        if (ResIndex >= popularResolutions.Count)
        {
            ResIndex = popularResolutions.Count - 1;
        }

        SetResolutionByIndex();
    }

    public void RemoveRes()
    {
        ResIndex--;

        if (ResIndex <= 0)
        {
            ResIndex = 0;
        }

        SetResolutionByIndex();
    }

    public void SetResolutionByIndex()
    {
        currentResolutionIndex = ResIndex;
        res = popularResolutions[currentResolutionIndex];

        ResText.text = $"{res.x} x {res.y}";

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
    }

    public void Apply()
    {
        Screen.SetResolution(res.x, res.y, FullScreenMode.FullScreenWindow);

        PlayerPrefs.SetInt("Res", ResIndex);

        StartCoroutine(CloseSettingsTimer());
    }

    IEnumerator CloseSettingsTimer()
    {
        yield return new WaitForSeconds(0.2f);
        Menu.SetActive(true);
        SettingsMenu.SetActive(false);
    }
}
