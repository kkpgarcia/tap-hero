using UnityEngine;
using System.Collections;

public class TransitionToGameState : GameState {
    public override void Enter() {
        ScoreController.Reset();
        AudioService.StopMusic(1.0f);
        GameController.ShowMenu(OnTransitionFinished);
    }

    private void OnTransitionFinished() {
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart() {
        yield return new WaitForSeconds(1);
        this.Owner.ChangeState<PlayingState>();
    }
}
