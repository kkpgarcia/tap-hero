using UnityEngine;

[CreateAssetMenu(menuName = "Song Info")]
public class SongInfo : ScriptableObject {
    public Track[] tracks;
    
    [System.Serializable]
    public class Track {
        public Note[] Notes;
    }

    [System.Serializable]
    public class Note {
        public float note;
    }
}
