using UnityEngine;
using System.Collections;

public class TransitionToGameState : GameState {
    public override void Enter() {
        AudioService.StopMusic(1.0f);
        GameController.ShowMenu(OnTransitionFinished);
    }

    private void OnTransitionFinished() {
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart() {
        AudioService.PlayMusic(AudioService.Music[1]);
        yield return new WaitForSeconds(1);
        this.Owner.ChangeState<PlayingState>();
    }
}
