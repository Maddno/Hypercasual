using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lastScoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI nickname;

    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        
        nickname.text = PlayerPrefs.GetString("saveNickname");
    }

    private void Start()
    {
        lastScoreText.text = $" {scoreKeeper.GetScore()}";
        bestScoreText.text = $" {scoreKeeper.GetBestScore()}";
    }

    public int LastScoreStatistick()
    {
        int lastScore = scoreKeeper.GetBestScore();

        return lastScore;
    }

    public int BestScoreStatistick()
    {
        int bestScore = scoreKeeper.GetScore();

        return bestScore;
    }

}
