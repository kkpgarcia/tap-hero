using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Conductor : MonoBehaviour {
    private float songLength;

    public float[] trackSpawnX;

    public float startLineY;
    public float finishLineY;

    public float removeLineY;

    public float badOffsetY;
    public float goodOffsetY;
    public float perfectOffsetY;

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

    private bool isInitialized = false;
    public SongInfo TestSong;
    private SongInfo.Track[] tracks;
    public MusicNode NodePrefab;
    public Transform NodeParent;
    
    public void Initialize(AudioService audioService) {
        m_AudioService = audioService;
        dspTimeSong = (float) AudioSettings.dspTime;
        crotchet = 60f / BPM;
        songLength = 1000;
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
        
        isInitialized = true;
    }

    void Update() {
        if (!isInitialized)
            return;
        
        songPosition = (float) (AudioSettings.dspTime - dspTimeSong) * m_AudioService.GetAudioSource().pitch;
        float beatToShow = songPosition / crotchet + BeatsShownOnScreen;

        for (int i = 0; i < len; i++) {
            int nextIndex = trackNextIndices[i];
            SongInfo.Track currTrack = tracks[i];
			
            if (nextIndex < currTrack.Notes.Length && currTrack.Notes[nextIndex].note < beatToShow)
            {
                SongInfo.Note currNote = currTrack.Notes[nextIndex];

                //get a new node
                MusicNode musicNode = Instantiate(NodePrefab);
                musicNode.transform.SetParent(NodeParent, true);
                musicNode.Initialize(trackSpawnX[i], startLineY, finishLineY, removeLineY, currNote.note, 1);
                musicNode.GetComponent<UnityEngine.UI.Image>().enabled = true;
                
                trackNextIndices[i]++;
            }
        }
    }
}
