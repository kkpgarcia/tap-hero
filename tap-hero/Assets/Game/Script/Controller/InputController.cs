using UnityEngine;
using System;

public class InputController : MonoBehaviour {
    public static event EventHandler<InfoEventArgs<Touch[]>> OnTouchInput;
    public static event EventHandler<InfoEventArgs<int>> OnTestInput;
    public void Update() {
        if (Input.touchCount > 0) {
            if (OnTouchInput != null) {
                Touch[] touches = Input.touches;
                OnTouchInput(this, new InfoEventArgs<Touch[]>(touches));
            }
        }
        
        /**
         * Testing Purposes
         */

        if (Input.GetKeyDown(KeyCode.K)) {
            if(OnTestInput != null)
                OnTestInput(this, new InfoEventArgs<int>(1));
        }

        if (Input.GetKeyDown(KeyCode.J)) {
            if(OnTestInput != null)
                OnTestInput(this, new InfoEventArgs<int>(-1));
            
        }
     }
}
