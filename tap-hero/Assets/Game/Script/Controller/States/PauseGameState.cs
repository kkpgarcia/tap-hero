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
        /**
         * Transition to result state
         */
        PauseController.Hide(() => {
            this.Owner.ChangeState<ShowResultState>();
        });
    }

    private void OnRestartGame() {
        /**
         * Clean-up state
         */
        
        /**
         * Restart Conductor
         */
        
        /**
         * Restart Score
         */
        
        PauseController.Hide(() => {
            this.Owner.ChangeState<TransitionToGameState>();
        });
    }
}
