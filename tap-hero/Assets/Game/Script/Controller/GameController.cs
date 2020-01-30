using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameController : MonoBehaviour {
    [SerializeField] private Button m_PauseButton;

    [SerializeField] private Panel m_HeaderPanel;
    [SerializeField] private Panel m_BodyPanel;
    [SerializeField] private Panel m_FooterPanel;

    private const string SHOW_KEY = "Show";
    private const string HIDE_KEY = "Hide";

    private void Start() {
        m_HeaderPanel.SetPosition(HIDE_KEY, false);
        m_BodyPanel.SetPosition(HIDE_KEY, false);
        m_FooterPanel.SetPosition(HIDE_KEY, false);
    }

    public void ShowMenu(UnityAction onFinish) {
        m_HeaderPanel.SetPosition(SHOW_KEY, true);
        m_BodyPanel.SetPosition(SHOW_KEY, true);
        Tweener footer = m_FooterPanel.SetPosition(SHOW_KEY, true);
        
        if (onFinish == null)
            return;
        
        footer.CompletedEvent += (s,a) => {
            onFinish.Invoke();
        };
    }

    public void HideMenu(UnityAction onFinish) {
        m_HeaderPanel.SetPosition(HIDE_KEY, true);
        m_BodyPanel.SetPosition(HIDE_KEY, true);
        Tweener footer = m_FooterPanel.SetPosition(HIDE_KEY, true);
        
        if (onFinish == null)
            return;
        
        footer.CompletedEvent += (s,a) => {
            onFinish.Invoke();
        };
    }

    public void AddPauseButtonListener(UnityAction action) {
        if (m_PauseButton != null)
            m_PauseButton.onClick.AddListener(action);
    }

    public void RemovePauseButtonListener(UnityAction action) {
        if(m_BodyPanel != null)
            m_PauseButton.onClick.RemoveListener(action);
    }
}
