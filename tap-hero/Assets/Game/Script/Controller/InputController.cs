using UnityEngine;
using System;

public class InputController : MonoBehaviour {
    public static event EventHandler<InfoEventArgs<Touch[]>> OnTouchInput;
    public void Update() {
        if (Input.touchCount > 0) {
            if (OnTouchInput != null) {
                Touch[] touches = Input.touches;
                OnTouchInput(this, new InfoEventArgs<Touch[]>(touches));
            }
        }
    }
}
