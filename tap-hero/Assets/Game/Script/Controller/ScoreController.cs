using UnityEngine;
using UnityEngine.UI;


public class ScoreController : MonoBehaviour {
    public const int PERFECT_SCORE = 100;
    public const int GREAT_SCORE = 30;

    public Text ScoreLabel;

    private int m_currentScore;
    private int Score {
        get { return m_currentScore; }
        set {
            m_currentScore = value;
            ScoreLabel.text = m_currentScore.ToString();
        }
    }

    public void Reset() {
        Score = 0;
    }
    
    public void AddScore(int score) {
        Score += score;
    }

    public int GetScore() {
        return Score;
    }
}
