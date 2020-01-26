using UnityEngine;

public class InitializeGameState : GameState {
    public override void Enter() {
        /*
         * All initialization goes here. Otherwise change to next
         * state.
         */
        this.Owner.ChangeState<LandingState>();
    }
    
    public override void Exit() {}
}
