using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {
    [SerializeField] private Text m_TimerLabel;
    private const int MAX_TIMER = 3;
    
    public void StartTimer(UnityAction onFinish) {
        m_TimerLabel.gameObject.SetActive(true);
        StartCoroutine(TimerRoutine(onFinish));
    }

    IEnumerator TimerRoutine(UnityAction onFinish) {
        int currentTimer = MAX_TIMER;

        while (currentTimer != 0) {
            m_TimerLabel.text = currentTimer.ToString();
            TweenLabel();
            yield return new WaitForSeconds(1);
            currentTimer--;
        }
        
        onFinish.Invoke();
        m_TimerLabel.gameObject.SetActive(false);
    }

    private void TweenLabel() {
        Transform trans = m_TimerLabel.rectTransform;
        Tweener tweener = trans.ScaleTo(Vector3.one * 1.25f, 0.5f);
        tweener.loopType = EasingControl.LoopType.PingPong;
        
        tweener.CompletedEvent += (s, a) => {
            trans.ScaleTo(Vector3.one, 0);
        };
        
    }
}
