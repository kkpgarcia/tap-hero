using UnityEngine;

public class LandingState : GameState {
    public override void Enter() {
        /**
         * Add Listeners to buttons
         */
        MenuController.ShowMenu(() => {
            MenuController.AddPlayButtonListener(OnStartGame);
            MenuController.AddAudioButtonListener(OnToggleButton);
        });
    }

    public override void Exit() {
        MenuController.RemovePlayButtonListener(OnStartGame);
        MenuController.RemoveAudioButtonListener(OnToggleButton);
    }

    public void OnStartGame() {
        MenuController.HideMenu(() => {
            Owner.ChangeState<TransitionToGameState>();
        });
    }

    public void OnToggleButton() {
        AudioService.ToggleAudio();
    }
}
