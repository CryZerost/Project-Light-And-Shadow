using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider musicVolume;
    public Slider sfxVolume;

    void Start()
    {
        LoadVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
        audioMixer.GetFloat("MasterVolume", out float masterVolume);
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
    }

    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
        audioMixer.GetFloat("MusicVolume", out float musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void UpdateSfxVolume(float volume)
    {
        audioMixer.SetFloat("SfxVolume", volume);
        audioMixer.GetFloat("SfxVolume", out float sfxVolume);
        PlayerPrefs.SetFloat("SfxVolume", sfxVolume);
    }

    public void LoadVolume()
    {
        float master = PlayerPrefs.GetFloat("MasterVolume", 0f);
        float music = PlayerPrefs.GetFloat("MusicVolume", 0f);
        float sfx = PlayerPrefs.GetFloat("SfxVolume", 0f);

        masterSlider.value = master;
        musicVolume.value = music;
        sfxVolume.value = sfx;

        UpdateMasterVolume(master);
        UpdateMusicVolume(music);
        UpdateSfxVolume(sfx);
    }
}
