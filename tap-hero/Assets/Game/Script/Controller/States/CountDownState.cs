using UnityEngine;


public class CountDownState : GameState {
    public override void Enter() {
        GameController.ShowMenu(null);
        PauseController.StartTimer(OnCountdonwFinished);
    }

    private void OnCountdonwFinished() {
        this.Owner.ChangeState<PlayingState>();
    }
}
