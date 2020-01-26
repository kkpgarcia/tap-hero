using UnityEngine;

public class PlayingState : GameState {
    public override void Enter() {
        base.Enter();
        GameController.AddPauseButtonListener(OnPause);
    }

    protected override void OnTouch(object sender, InfoEventArgs<Touch[]> info) {
        base.OnTouch(sender, info);
        
        /**
         * Send touch positions to conductor class for assessment
         */
    }

    private void OnPause() {
        GameController.HideMenu(() => {
            this.Owner.ChangeState<PauseGameState>();
        });
    }

    private void OnLose() {}
    private void OnWin() {}
}
