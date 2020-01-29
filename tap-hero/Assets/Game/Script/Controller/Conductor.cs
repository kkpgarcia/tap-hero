using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;

public class Conductor : MonoBehaviour {
    public enum Rank {
        PERFECT,
        GOOD,
        MISS
    }
    
    private float songLength;

    public float[] trackSpawnX;
    public float finishLineY;
    public float removeLineY;
    
    public float BPM;
    
    public static float songPosition;
    public static float crotchet;

    private int[] trackNextIndices;
    private Queue<MusicNode>[] queueForTracks;
    private MusicNode[] previousMusicNodes;

    private float dspTimeSong;
    public static float BeatsShownOnScreen = 4f;

    private AudioService m_AudioService;
    private int len;

    private bool paused = false;
    public SongInfo TestSong;
    private SongInfo.Track[] tracks;
    
    public MusicNode NodePrefab;
    public Transform LeftParent;
    public Transform RightParent;
    

    private UnityAction m_OnFinish;
    private UnityAction<MusicNode, Rank> m_OnInput;
    
    private List<MusicNode> m_NodeReference = new List<MusicNode>();
    
    private List<SongInfo.Note> L = new List<SongInfo.Note>();
    private List<SongInfo.Note> R = new List<SongInfo.Note>();
    
    public void Initialize(AudioService audioService) {
        m_AudioService = audioService;
        
    }
    
    public void StartSong(UnityAction onFinish, UnityAction<MusicNode, Rank> onInput) {
        if (paused) {
            Play();
            return;
        }

        CleanData();
        
        Debug.Log("Starting");
        m_AudioService.GetAudioSource().loop = false;
        m_OnFinish = onFinish;
        m_OnInput = onInput;
        m_AudioService.PlayMusic(m_AudioService.Music[1]);
    }

    public void Pause() {
        paused = true;
        m_AudioService.PauseMusic();
    }

    public void Unpause() {
        paused = false;
    }
    
    public void Play() {
        paused = false;
        m_AudioService.PlayMusic();
    }

    public void Stop() {
        paused = false;
        StartCoroutine(DestroyRoutine());
    }

    IEnumerator DestroyRoutine() {
        while (queueForTracks[0].Count != 0) {
            MusicNode n = queueForTracks[0].Dequeue();
            Destroy(n.gameObject);
            yield return null;
        }
        
        while (queueForTracks[1].Count != 0) {
            MusicNode n = queueForTracks[1].Dequeue();
            Destroy(n.gameObject);
            yield return null;
        }
    }

    public void Restart() {
        Stop();
        m_AudioService.GetAudioSource().time = 0;

        CleanData();
    }

    private void CleanData() {
        dspTimeSong = (float) AudioSettings.dspTime;
        crotchet = 60f / BPM;
        songLength = 60f;
        len = trackSpawnX.Length;
        trackNextIndices = new int[len];
        
        queueForTracks = new Queue<MusicNode>[len];
        previousMusicNodes = new MusicNode[len];
        
        for (int i = 0; i < len; i++)
        {
            trackNextIndices[i] = 0;
            queueForTracks[i] = new Queue<MusicNode>();
            previousMusicNodes[i] = null;
        }
        
        tracks = TestSong.tracks;
    }

    public void AsessInput(int position) {
        int currentInput = position == -1 ? 0 : 1;

        if (queueForTracks.Length == 0)
            return;

        if (queueForTracks[currentInput].Count == 0)
            return;

        MusicNode currentNode = queueForTracks[currentInput].Dequeue();

        if (currentNode == null)
            return;

        Rank inputRank;
        
        if (Mathf.Abs(songPosition - currentNode.beat) < 2f) {
            inputRank = Rank.PERFECT;
        }
        else if (Mathf.Abs(songPosition - currentNode.beat) < 2.5f) {
            inputRank = Rank.GOOD;
        }
        else {
            inputRank = Rank.MISS;
        }
        
        m_OnInput.Invoke(currentNode, inputRank);
    }

    public void OnUpdate() {
        if (paused) {
            return;
        }
        
        songPosition = (float) (AudioSettings.dspTime - dspTimeSong) * m_AudioService.GetAudioSource().pitch;
        float beatToShow = songPosition / crotchet + BeatsShownOnScreen;

        for (int i = 0; i < len; i++) {
            int nextIndex = trackNextIndices[i];
            SongInfo.Track currTrack = tracks[i];
            
            if (nextIndex < currTrack.Notes.Length && currTrack.Notes[nextIndex].note < beatToShow)
            {
                SongInfo.Note currNote = currTrack.Notes[nextIndex];
            
                MusicNode musicNode = Instantiate(NodePrefab, new Vector3(i == 0 ? LeftParent.position.x : RightParent.position.x, Screen.height + 200, 0), this.transform.rotation, i == 0 ? LeftParent : RightParent);
                musicNode.Initialize(i == 0 ? LeftParent.position.x : RightParent.position.x, Screen.height + 200, finishLineY, removeLineY, currNote.note, 1);
                musicNode.GetComponent<UnityEngine.UI.Image>().enabled = true;

                //m_NodeReference.Add(musicNode);
                trackNextIndices[i]++; 
                queueForTracks[i].Enqueue(musicNode);
            }
        }

        if (songPosition > songLength) {
            if (m_OnFinish != null) {
                m_OnFinish.Invoke();
                paused = true;

                m_OnFinish = null;
                m_OnInput = null;
            }
        }
    }
}
