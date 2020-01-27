using UnityEngine;
using UnityEngine.Events;

public class AudioService : MonoBehaviour {
    [SerializeField] private AudioSource m_MainSource;
    [SerializeField] private AudioSource m_SecondarySource;
    
    [SerializeField] private ButtonImageToggler[] ImageTogglers;

    /**
     * This array is for simplicity. Audio should be loaded from resources or
     * scriptable object of levels.
     *
     * 0 - Main Music
     * 1 - Level Music
     */
    public AudioClip[] Music;
    
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

    public void PlayMusic(AudioClip clip = null) {
        if(clip != null)
            m_MainSource.clip = clip;

        m_MainSource.VolumeTo(1.0f, 0.5f);
        m_MainSource.Play();
    }

    public void PauseMusic() {
        StopMusic(0.25f);
    }
    
    public void StopMusic(float fadeDuration, bool repeat = false, UnityAction action = null) {
        Tweener Tweener = m_MainSource.VolumeTo(0.0f, fadeDuration);

        Tweener.CompletedEvent += (s, a) => {
            if (repeat) {
                m_MainSource.time = 0;
            }
            else {
                m_MainSource.Pause();
            }
            
            if(action != null)
                action.Invoke();
        };
    }

    public void PlaySFX(AudioClip clip) {
        m_MainSource.PlayOneShot(clip);
    }

    public AudioSource GetAudioSource() {
        return m_MainSource;
    }
}
