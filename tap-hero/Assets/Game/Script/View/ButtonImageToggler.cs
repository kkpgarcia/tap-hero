using UnityEngine;
using UnityEngine.UI;

public class ButtonImageToggler : MonoBehaviour {
    [SerializeField] private Button m_Button;
    [SerializeField] private Sprite m_ActivatedImage;
    [SerializeField] private Sprite m_DeactivatedImage;

    private bool isToggled = true;

    public void Toggle() {
        isToggled = !isToggled;
        m_Button.image.sprite = isToggled ? m_ActivatedImage : m_DeactivatedImage;
    }
}
