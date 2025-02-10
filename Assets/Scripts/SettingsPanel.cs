using UnityEngine;
using UnityEngine.Audio;

public class SettingsPanel : MonoBehaviour
{
    private const int DecibelScaleFactor = 20;
    private const int MinDecibel = -80;

    [SerializeField] private AudioMixerGroup _mixer;

    private string _masterVolumeName = "Master";
    private string _musicVolumeName = "Music";
    private string _uiVolumeName = "UI";

    private float _currentMusicVolume = 1;

    public void SetMasterVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(_masterVolumeName, Mathf.Log10(volume) * DecibelScaleFactor);
    }

    public void SetMusicVolume(float volume)
    {
        _currentMusicVolume = volume;
        _mixer.audioMixer.SetFloat(_musicVolumeName, Mathf.Log10(volume) * DecibelScaleFactor);
    }

    public void SetUIVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(_uiVolumeName, Mathf.Log10(volume) * DecibelScaleFactor);
    }

    public void ToggleMusicVolume(bool enabled)
    {
        if (enabled)
            _mixer.audioMixer.SetFloat(_musicVolumeName, Mathf.Log10(_currentMusicVolume) * DecibelScaleFactor);
        else
            _mixer.audioMixer.SetFloat(_musicVolumeName, Mathf.Log10(MinDecibel) * DecibelScaleFactor);
    }
}
