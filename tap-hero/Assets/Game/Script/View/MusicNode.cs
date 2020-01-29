using System;
using UnityEngine;

public class MusicNode : MonoBehaviour {

    private float startY;
    private float endY;
    public float beat;
    private float removeLineY;
    
    public const string OnMissNode = "MusicNode.OnMissNode";

    private bool m_StopUpdate = false;
    
    public void Initialize(float posX, float startY, float endY, float removeLineY, float targetBeat) {
        this.startY = startY;
        this.endY = endY;
        this.beat = targetBeat;
        this.removeLineY = removeLineY;

        transform.position = new Vector2(posX, startY);
    }

    private void Update() {
        if (m_StopUpdate)
            return;
        
        transform.position = new Vector2(transform.position.x,
            startY + (endY - startY) *
            (1f - (beat - Conductor.songPosition / Conductor.crotchet / Conductor.BeatsShownOnScreen)));

        if (this.transform.position.y < removeLineY) {
            OnMiss();
            m_StopUpdate = true;
        }
    }

    public void OnMiss() {
        this.PostNotification(OnMissNode);
    }
}
