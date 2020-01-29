using System;
using UnityEngine;

public class PlayingState : GameState {
    
    public override void Enter() {
        base.Enter();
        Conductor.Initialize(AudioService);
        
        Conductor.Unpause();
        Conductor.StartSong(OnFinish, OnInput);
        GameController.AddPauseButtonListener(OnPause);
    }

    protected override void OnTouch(object sender, InfoEventArgs<Touch[]> info) {
        Touch[] touches = info.Arg0;

        if (touches.Length > 0) {
            Touch firstTouch = touches[0];

            if (firstTouch.phase == TouchPhase.Began) {
                int input = firstTouch.position.x < Screen.width / 2 ? -1 : 1;
                Conductor.AsessInput(input);
            }
        }
    }

    protected override void OnTest(object sender, InfoEventArgs<int> info) {
        int input = info.Arg0;
        Conductor.AsessInput(input);
    }

    private void OnInput(MusicNode node, Conductor.Rank rank) {
        switch (rank) {
            case Conductor.Rank.PERFECT:
                ScoreController.AddScore(ScoreController.PERFECT_SCORE);
                break;
            case Conductor.Rank.GOOD:
                ScoreController.AddScore(ScoreController.GREAT_SCORE);
                break;
            case Conductor.Rank.MISS:
                ScoreController.AddScore(-25);
                break;
        }
        
        Destroy(node.gameObject);
    }

    private void Update() {
        Conductor.OnUpdate();
    }

    private void OnPause() {
        Conductor.Pause();
        GameController.HideMenu(() => {
            this.Owner.ChangeState<PauseGameState>();
        });
    }

    private void OnFinish() {
        Conductor.Stop();
        GameController.HideMenu(() => {
            this.Owner.ChangeState<ShowResultState>();
        });
    }
}
