using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private const string mainThemeAudioName = "Main Theme";

    public Audio[] audios;

    public static AudioManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Audio audio in audios)
        {
            audio.source = gameObject.AddComponent<AudioSource>();
            audio.source.clip = audio.clip;

            audio.source.volume = audio.volume;
            audio.source.pitch = audio.pitch;

            audio.source.loop = audio.isLoop;
        }
    }

    public void Start()
    {
        Play(mainThemeAudioName);
    }

    public void Play(string name)
    {
        Audio audio = Array.Find(audios, a => a.name.Equals(name));

        if (audio == null)
        {
            string message = $"Audio: {name} is not found.";
            Debug.LogWarning(message);
            return;
        }

        audio.source.Play();
    }
}
