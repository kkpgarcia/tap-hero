using UnityEngine;

public class InitializeGameState : GameState {
    public override void Enter() {
        /*
         * All initialization goes here. Otherwise change to next
         * state.
         */
        Application.targetFrameRate = 60;
        PersistentDataModel.GameSettings = new GameSettings();
        
        this.Owner.ChangeState<LandingState>();
    }
    
    public override void Exit() {}
}
