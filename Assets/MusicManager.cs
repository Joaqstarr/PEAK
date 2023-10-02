using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using DG.Tweening;
public class MusicManager : MonoBehaviour
{
    [SerializeField]
    AudioMixer _mixer;
    float _forestVolume = 0;
    float _facilityVolume = 0;
    float _worldVolume = 0;
    float _emptyBossRoom = 0;
    [SerializeField]
    float _transitionTime = 3f;
    [SerializeField]
    AudioSource _bossMusic;
    // Start is called before the first frame update
    void Start()
    {
        _mixer.GetFloat("ForestMusicVol", out _forestVolume);
        _mixer.GetFloat("FacilityMusicVol", out _facilityVolume);
        _mixer.GetFloat("WorldMusicVol", out _worldVolume);
        _mixer.GetFloat("EmptyBossRoomVol", out _emptyBossRoom);

        _mixer.SetFloat("ForestMusicVol", -80f);
        _mixer.SetFloat("FacilityMusicVol", -80f);
        _mixer.SetFloat("EmptyBossRoomVol", -80f);
        _mixer.SetFloat("BossRoomVol", -80);

        if (OutdootEffects._outdoors)
        {
            _mixer.SetFloat("ForestMusicVol", _forestVolume);

        }
        else
        {
            _mixer.SetFloat("FacilityMusicVol", _facilityVolume);

        }


    }
    public void TransitionMusic(bool outdoors, bool boss)
    {
        _mixer.DOSetFloat("EmptyBossRoomVol", boss ?_emptyBossRoom : -80, _transitionTime);
        _mixer.DOSetFloat("BossRoomVol", boss ? 0 : -80, _transitionTime);

        _mixer.DOSetFloat("WorldMusicVol", boss ? -80 : _worldVolume, _transitionTime);

        _mixer.DOSetFloat("ForestMusicVol", outdoors? _forestVolume : -80f, _transitionTime);
        _mixer.DOSetFloat("FacilityMusicVol", outdoors ? -80 : _facilityVolume, _transitionTime);


    }
    public void StartBossMusic()
    {
        _bossMusic.Play();
        _mixer.DOSetFloat("EmptyBossRoomVol", -80, _transitionTime);

    }
    public void EndBossMusic()
    {
        _mixer.DOSetFloat("BossMusicVol", -80, _transitionTime);
        _mixer.DOSetFloat("EmptyBossRoomVol", _emptyBossRoom, _transitionTime);


    }
}
