using UnityEngine.Audio;
using UnityEngine.UI;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Toggle toggleButton;
    public Sound[] sounds;
    public bool isToggleOn;
    public static AudioManager instanceAudioManager;

	// Use this for initialization
	void Awake () {
        if (instanceAudioManager == null)
        {
            instanceAudioManager = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
             
            foreach(Sound i in sounds)
            {
                i.source = gameObject.AddComponent<AudioSource>();
                i.source.clip = i.clip;
                i.source.volume = i.volume;
                i.source.loop = i.loop;
            }
	}

    private void Start()
    {              
            PlaySounds("musicBackground"); 
    }
    private void Update()
    {
        StopPlaySounds();      
    }

    public void StopPlaySounds()
    {
        if(toggleButton == null)
        {
            return;
        }
        if (toggleButton.isOn)
        {
            isToggleOn = true;
            foreach(Sound i in sounds)
            {
                i.source.mute = true;
            }
        }
        else
        {
            isToggleOn = false;
            foreach (Sound i in sounds)
            {
                i.source.mute = false;
            }
        }
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            return;
        }
        s.source.Stop();
    }

    public void PlaySounds(string nameOfSound)
    {
        Sound s = Array.Find(sounds, sound => sound.name == nameOfSound);

            if(s == null)
            {
                return;
            }
            s.source.Play();         
    }
}
