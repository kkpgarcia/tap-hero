using UnityEngine;

public class AudioService : MonoBehaviour {
    [SerializeField] private AudioSource m_MainSource;
    [SerializeField] private AudioSource m_SecondarySource;
    
    [SerializeField] private ButtonImageToggler[] ImageTogglers;
    
    public bool isAudioActivated {
        get {
            return PersistentDataModel.GameSettings.Audio; 
        }
    }

    public void ToggleAudio() {
        foreach (ButtonImageToggler i in ImageTogglers) {
            i.Toggle();
        }

        PersistentDataModel.GameSettings.Audio = !PersistentDataModel.GameSettings.Audio;
        m_MainSource.VolumeTo(isAudioActivated ? 1.0f : 0.0f, 0.25f);
    }

    public void PlayMusic(AudioClip clip) {
        m_MainSource.clip = clip;
        m_MainSource.Play();
    }

    public void PlaySFX(AudioClip clip) {
        m_MainSource.PlayOneShot(clip);
    }
}
