using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;

public class NewAudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static NewAudioManager instance;
    [SerializeField] Slider volumeSlider;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Destoryed");
            Destroy(gameObject);
            return;
        }
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        else
        {
            Load();
        }
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        if (s == null)
        {
            Debug.LogWarning("No Sound");
            return;
        }
    }
    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Pause();
        if (s == null)
        {
            Debug.LogWarning("No Sound");
            return;
        }
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
        if (s == null)
        {
            Debug.LogWarning("No Sound");
            return;
        }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volumeSlider.value;
        // audioMixer.SetFloat("Volume", volume);
        Save();
    }
    void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }


}
