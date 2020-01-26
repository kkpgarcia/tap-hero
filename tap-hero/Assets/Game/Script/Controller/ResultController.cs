using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ResultController : MonoBehaviour {
    [SerializeField] private Button m_HomeButton;
    [SerializeField] private Button m_RestartButton;
    [SerializeField] private Button m_NextButton;
    [SerializeField] private Panel m_ResultPanel;
    [SerializeField] private Image m_Overlay;

    private const string SHOW_KEY = "Show";
    private const string HIDE_KEY = "Hide";

    private void Start() {
        m_ResultPanel.SetPosition(HIDE_KEY, false);
    }

    public void Show(UnityAction onFinish) {
        /**
         * Unity Bug on crossfade alpha where it doesn't work if
         * the object is not set to disabled and enabled right after
         */
        m_Overlay.gameObject.SetActive(false);
        m_Overlay.gameObject.SetActive(true);
        
        m_Overlay.CrossFadeAlpha(0.5f, 1f, false);
        m_Overlay.raycastTarget = true;
        Tweener panel = m_ResultPanel.SetPosition(SHOW_KEY, true);
        
        if (onFinish == null)
            return;
        
        panel.CompletedEvent += (sender, args) => onFinish.Invoke();
    }

    public void Hide(UnityAction onFinish) {
        /**
         * Unity Bug on crossfade alpha where it doesn't work if
         * the object is not set to disabled and enabled right after
         */
        m_Overlay.gameObject.SetActive(false);
        m_Overlay.gameObject.SetActive(true);
        
        m_Overlay.CrossFadeAlpha(0.01f, 1f, false);
        m_Overlay.raycastTarget = false;
        Tweener panel = m_ResultPanel.SetPosition(HIDE_KEY, true);
        
        if (onFinish == null)
            return;
        
        panel.CompletedEvent += (sender, args) => onFinish.Invoke();
    }
    
    public void AddHomeButtonListener(UnityAction action) {
        if(m_HomeButton != null)
            m_HomeButton.onClick.AddListener(action);
    }

    public void AddRestartButtonListener(UnityAction action) {
        if(m_RestartButton != null)
            m_RestartButton.onClick.AddListener(action);
    }

    public void AddNextButtonListener(UnityAction action) {
        if(m_NextButton != null)
            m_NextButton.onClick.AddListener(action);
    }

    public void RemoveHomeButtonListener(UnityAction action) {
        if(m_HomeButton != null)
            m_HomeButton.onClick.RemoveListener(action);
    }

    public void RemoveRestartButtonListener(UnityAction action) {
        if(m_RestartButton != null)
            m_RestartButton.onClick.RemoveListener(action);
    }

    public void RemoveNextButtonListener(UnityAction action) {
        if(m_NextButton != null)
            m_NextButton.onClick.RemoveListener(action);
    }
}
