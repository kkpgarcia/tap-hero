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

    protected PauseController PauseController {
        get { return Owner.PauseController; }
    }

    protected ResultController ResultController {
        get { return Owner.ResultController; }
    }

    protected AudioService AudioService {
        get { return Owner.AudioService; }
    }

    protected Conductor Conductor {
        get { return Owner.Conductor; }
    }

    protected ScoreController ScoreController {
        get { return Owner.ScoreController; }
    }

    public void Awake() {
        Owner = this.GetComponent<GameBootstrap>();
    }

    protected override void AddListeners() {
        InputController.OnTouchInput += OnTouch;
        InputController.OnTestInput += OnTest;
    }

    protected override void RemoveListeners() {
        InputController.OnTouchInput -= OnTouch;
        InputController.OnTestInput -= OnTest;
    }

    protected virtual void OnTouch(object sender, InfoEventArgs<Touch[]> info) { }
    protected virtual void OnTest(object sender, InfoEventArgs<int> info) { }
}
