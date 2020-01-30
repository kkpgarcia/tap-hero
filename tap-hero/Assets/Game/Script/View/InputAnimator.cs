using UnityEngine;
using UnityEngine.UI;

public class InputAnimator : MonoBehaviour {
    public RectTransform OuterLine;
    public RectTransform InnerLine;
    private void Start() {
        Rotate();
    }

    public void Rotate() {
        Tweener tween = OuterLine.RotateToLocal(new Vector3(0, 0, 360), 5, EasingEquations.Linear);
        tween.loopCount = -1;
    }

    public void Scale() {
        Tweener tween = OuterLine.ScaleTo(Vector2.one * 1.25f, 0.05f, EasingEquations.EaseInCubic);
        tween.loopType = EasingControl.LoopType.PingPong;
        tween.CompletedEvent += (s,a) => { OuterLine.ScaleTo(Vector2.one, 0.05f, EasingEquations.EaseInCubic); };
    }
}
