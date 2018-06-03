﻿using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Sound  {

    public AudioClip clip;
    public string name;
    public bool loop;

    [Range(0f, 1f)]
    public float volume;

    [HideInInspector]
    public AudioSource source;
}
