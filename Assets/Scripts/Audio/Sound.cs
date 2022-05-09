using UnityEngine;

[System.Serializable]
public class Sound {
    public string Name;

    public AudioClip Clip;
    public string SoundType;
    [HideInInspector] public AudioSource Source;

    [Range(0f, 1f)] public float Volume;
    [Range(.1f, 3f)] public float Pitch;
    public bool Loop;
    public float maxVolume;
}