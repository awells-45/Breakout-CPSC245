using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    private new static AudioManager instance;

    public new static AudioManager Instance {
        get { return instance; }
    }
    public float musicCurrentVolume = 1f;
    public float soundeffectsCurrentVolume = 1f;
    public Sound[] Sounds;

    private void OnEnable() {
    }

    private void OnDisable() {
    }

    void Awake() {
        instance = this;

        // Sets up the audio source components for each audio file
        foreach (Sound sound in Sounds) {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;
            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.Loop;
        }
    }

    // Plays the sound corresponding to the inputted argument
    
    public void Play(string name) {
            print(name);
            Sound sound = Array.Find(Sounds, sound => sound.Name == name);

            if (sound == null) {
                Debug.LogWarning("Sound: " + name + " not found! Cannot play!");
                return;
            }

            // Keeps audio from playing consecutively multiple times if it is already playing. Useful for platforms
            if ((sound.SoundType == "SoundEffect") && (sound.Source.isPlaying)) {
                // Debug.Log("Sound Already Playing");
                return;
            }

            // sound.Source.volume = volume;
            sound.Source.Play();
    }
    
    public void SetVolume(string trackName, float volume)
    {
        Sound track = Array.Find(Sounds, sound => sound.Name == trackName);

        if (track == null)
        {
            Debug.LogWarning("Sound: " + trackName + " not found!");
            return;
        }

        track.Source.volume = volume;
    }

    public void Pause(string type)
    {
        Sound[] sounds = Array.FindAll(Sounds, sound => sound.SoundType == type);

        foreach (Sound sound in sounds)
        {
            if (sound == null)
            {
                Debug.LogWarning("Sound: " + sound.Name + " not found! Cannot play!");
                continue;
            }

            if (!sound.Source.isPlaying)
            {
                continue;
            }

            if (sound.Source.isPlaying)
            {
                sound.Source.Pause();
            }
        }
    }

    public void ChangeVolume(string soundType, float newVolume) {
            foreach (Sound sound in Sounds) {
                if (sound.SoundType == soundType) {
                    if (sound.SoundType == "Music") {
                        musicCurrentVolume = newVolume;
                    }
                    else if (sound.SoundType == "SoundEffect") {
                        soundeffectsCurrentVolume = newVolume;
                    }

                    sound.Volume = newVolume * sound.maxVolume;
                    sound.Source.volume = sound.Volume;
                }
            }
        }
        
        public void Resume(string type) {
            Sound[] sounds = Array.FindAll(Sounds, sound => sound.SoundType == type);

            foreach (Sound sound in sounds) {
                if (sound == null) {
                    Debug.LogWarning("Sound: " + sound.Name + " not found! Cannot resume!");
                    continue;
                }

                if (sound.Source.isPlaying) {
                    Debug.LogWarning("Sound: " + sound.Name + " is currently playing!");
                    continue;
                }

                if (!sound.Source.isPlaying && sound.Source.time > 0) {
                    sound.Source.UnPause();
                }
            }
        }
        
        public void Stop(string type) {
            Sound[] soundsToStop = Array.FindAll(Sounds, sound => sound.SoundType == type);

            foreach (Sound sound in soundsToStop) {
                sound.Source.Stop();
            }

            StopFadingAndResetSoundVolumes();
        }
        
        protected void StopFadingAndResetSoundVolumes() {
            StopCoroutine(FadeVolumes(null, null));

            Sound[] resetVolumeSounds = Array.FindAll(Sounds, sound => sound.SoundType == "Music");
            foreach (Sound sound in resetVolumeSounds) {
                sound.Source.volume = sound.Volume;
            }
        }

        public void FadeTracks(string track1Name, string track2Name) {
            Sound sound1 = Array.Find(Sounds, sound => sound.Name == track1Name);
            Sound sound2 = Array.Find(Sounds, sound => sound.Name == track2Name);

            if (sound1 == null || sound2 == null) {
                Debug.LogWarning(track1Name + " or " + track2Name + " is NULL. Cannot fade between tracks!");
                return;
            }

            StartCoroutine(FadeVolumes(sound1, sound2));
        }

        protected IEnumerator FadeVolumes(Sound sound1, Sound sound2) {
            sound2.Source.volume = 0;
            sound2.Source.Play();

            while (sound1.Source.volume > 0 && sound2.Source.volume < sound2.maxVolume) {
                sound2.Source.volume += .0133f;
                sound1.Source.volume -= .0133f;
                yield return new WaitForSeconds(.1f);
            }

            sound1.Source.Stop();
            sound1.Source.volume = sound1.maxVolume;
        }

        

    public float GetVolume(string soundType) {
        foreach (Sound sound in Sounds) {
            if (sound.SoundType == soundType) {
                return sound.Volume;
            }
        }

        return -1f;
    }
}