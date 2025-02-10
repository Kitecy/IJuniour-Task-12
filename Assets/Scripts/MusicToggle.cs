using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MusicToggle : MonoBehaviour
{
    private const int LogBase = 10;

    [SerializeField] private AudioMixerGroup _mixer;

    private float _previousVolume = 1;

    private Toggle _toggle;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(Switch);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(Switch);
    }

    public void Switch(bool enabled)
    {
        if (enabled)
        {
            _mixer.audioMixer.SetFloat(_mixer.name, Mathf.Log10(_previousVolume) * Utils.DecibelScaleFactor);
        }
        else
        {
            if (_mixer.audioMixer.GetFloat(_mixer.name, out float volume))
                _previousVolume = Mathf.Pow(LogBase, volume / Utils.DecibelScaleFactor);

            _mixer.audioMixer.SetFloat(_mixer.name, -80);
        }

        _toggle.SetIsOnWithoutNotify(enabled);
    }
}
