public class ShowResultState : GameState {
    public override void Enter() {
        ResultController.Show(() => {
            ResultController.AddHomeButtonListener(OnClickedHome);
            ResultController.AddNextButtonListener(OnNextLevel);
            ResultController.AddRestartButtonListener(OnRestart);
            ResultController.AddAudioButtonListener(OnToggleAudio);
            Animate();
        });
        
    }

    public override void Exit() {
        ResultController.Hide(() => {
            ResultController.RemoveHomeButtonListener(OnClickedHome);
            ResultController.RemoveNextButtonListener(OnNextLevel);
            ResultController.RemoveRestartButtonListener(OnRestart);
            ResultController.RemoveAudioButtonListener(OnToggleAudio);
        });
    }

    private void Animate() {
        /**
         * Animate Star
         */
        
        /*
         * Animate Score
         */
    }

    private void OnClickedHome() {
        this.Owner.ChangeState<LandingState>();
    }

    private void OnRestart() {
        /**
         * Restart Conductor
         */
        
        /**
         * Restart Score
         */
        this.ResultController.Hide(() => {
            this.Owner.ChangeState<TransitionToGameState>();
        });
    }

    private void OnNextLevel() {
        OnRestart();
    }

    private void OnToggleAudio() {
        AudioService.ToggleAudio();
    }
}