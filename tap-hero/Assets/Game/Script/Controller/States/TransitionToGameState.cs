public class TransitionToGameState : GameState {
    public override void Enter() {
        GameController.ShowMenu(OnTransitionFinished);
    }

    private void OnTransitionFinished() {
        this.Owner.ChangeState<PlayingState>();
    }
}
