using UnityEngine;

public class LandingState : GameState {
    public override void Enter() {
        /**
         * Add Listeners to buttons
         */
        MenuController.ShowMenu(() => {
            MenuController.AddPlayButtonListener(StartGame);
            MenuController.AddSettingsButtonListener(OpenSettings);
        });
    }

    public override void Exit() {
        MenuController.RemovePlayButtonListener(StartGame);
        MenuController.RemoveSettingsButtonListener(OpenSettings);
    }

    public void StartGame() {
        MenuController.HideMenu(() => {
            Owner.ChangeState<TransitionToGameState>();
        });
    }

    public void OpenSettings() {
        
    }
}
