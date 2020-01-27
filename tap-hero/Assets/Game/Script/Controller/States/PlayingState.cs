using UnityEngine;

public class PlayingState : GameState {
    public override void Enter() {
        base.Enter();
       
        Conductor.Initialize(AudioService);
        
        GameController.AddPauseButtonListener(OnPause);
    }

    protected override void OnTest(object sender, InfoEventArgs<int> info) {
        base.OnTest(sender, info);

        int input = info.Arg0;

        if (input == -1) {
            Debug.Log("Input on Left");
        }

        if (input == 1) {
            Debug.Log("Input on Right");
        }
    }

    private void OnPause() {
        GameController.HideMenu(() => {
            this.Owner.ChangeState<PauseGameState>();
        });
    }

    private void OnLose() {}
    private void OnWin() {}
}
