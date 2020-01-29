using System;
using UnityEngine;

public class MusicNode : MonoBehaviour {

    private float startY;
    private float endY;
    public float beat;
    private float removeLineY;
    private int times;

    public void Initialize(float posX, float startY, float endY, float removeLineY, float targetBeat, int times) {
        this.startY = startY;
        this.endY = endY;
        this.beat = targetBeat;
        this.times = times;
        this.removeLineY = removeLineY;

        transform.position = new Vector2(posX, startY);
    }

    private void Update() {
        transform.position = new Vector2(transform.position.x,
            startY + (endY - startY) *
            (1f - (beat - Conductor.songPosition / Conductor.crotchet / Conductor.BeatsShownOnScreen)));
    }
}
