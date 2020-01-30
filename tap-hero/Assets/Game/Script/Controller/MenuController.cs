using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Collections;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button m_PlayButton;
    [SerializeField] public Button m_AudioButton;
    [SerializeField] public Panel TitlePanel;
    [SerializeField] public Panel FooterPanel;

    private const string SHOW_KEY = "Show";
    private const string HIDE_KEY = "Hide";

    private void Start() {
        TitlePanel.SetPosition(HIDE_KEY, false);
        FooterPanel.SetPosition(HIDE_KEY, false);
    }
    
    public void ShowMenu(UnityAction onFinish) {
        TitlePanel.SetPosition(SHOW_KEY, true);
        Tweener footer = FooterPanel.SetPosition(SHOW_KEY, true);
        
        if (onFinish == null)
            return;

        footer.CompletedEvent += (s, e) => { onFinish.Invoke(); };
    }

    public void HideMenu(UnityAction onFinish) {
        TitlePanel.SetPosition(HIDE_KEY, true);
        Tweener footer = FooterPanel.SetPosition(HIDE_KEY, true);

        if (onFinish == null)
            return;
        
        footer.CompletedEvent += (s, e) => { onFinish.Invoke(); };
    }
    
    public void AddPlayButtonListener(UnityAction action) {
        if(m_PlayButton != null)
            m_PlayButton.onClick.AddListener(action);
    }

    public void AddAudioButtonListener(UnityAction action) {
        if(m_AudioButton != null)
            m_AudioButton.onClick.AddListener(action);
    }
    
    public void RemovePlayButtonListener(UnityAction action) {
        if(m_PlayButton != null)
            m_PlayButton.onClick.RemoveListener(action);
    }

    public void RemoveAudioButtonListener(UnityAction action) {
        if(m_AudioButton != null)
            m_AudioButton.onClick.RemoveListener(action);
    }
}

