using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundVolumeHandler : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;


    public void SetMusicVol(float vol)
    {
        musicMixer.SetFloat("MusicVol", vol);
    }
    public void SetSFXVol(float vol)
    {
        sfxMixer.SetFloat("SFXVol", vol);
    }
}
