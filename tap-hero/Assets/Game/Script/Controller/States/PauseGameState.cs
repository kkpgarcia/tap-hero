public class PauseGameState : GameState {
    public override void Enter() {
        PauseController.Show(null);
        PauseController.AddPlayButtonListener(OnContinue);
        PauseController.AddHomeButtonListener(OnExitGame);
        PauseController.AddRestartButtonListener(OnRestartGame);
    }

    public override void Exit() {
        PauseController.RemovePlayButtonListener(OnContinue);
        PauseController.RemoveHomeButtonListener(OnExitGame);
        PauseController.RemoveRestartButtonListener(OnRestartGame);
    }

    private void OnContinue() {
        PauseController.Hide(() => {
            GameController.ShowMenu(null);
            PauseController.StartTimer(() => {
                this.Owner.ChangeState<PlayingState>();
            });
        });
    }

    private void OnExitGame() {
        Conductor.Stop();
        PauseController.Hide(() => {
            this.Owner.ChangeState<ShowResultState>();
        });
    }

    private void OnRestartGame() {
        Conductor.Restart();
        ScoreController.Reset();
        
        PauseController.Hide(() => {
            this.Owner.ChangeState<TransitionToGameState>();
        });
    }
}
