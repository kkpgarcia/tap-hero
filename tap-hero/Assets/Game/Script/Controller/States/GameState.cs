using System;
using UnityEngine;

public class GameState : State {
    public GameBootstrap Owner;
    protected MenuController MenuController {
        get { return Owner.MenuController; }
    }

    protected GameController GameController {
        get { return Owner.GameController; }
    }

    public void Awake() {
        Owner = this.GetComponent<GameBootstrap>();
    }

    protected override void AddListeners() {
        InputController.OnTouchInput += OnTouch;
    }

    protected override void RemoveListeners() {
        InputController.OnTouchInput -= OnTouch;
    }

    protected virtual void OnTouch(object sender, InfoEventArgs<Touch[]> info) { }
}
