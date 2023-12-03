using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lastScoreText;
    [SerializeField] TextMeshProUGUI nickname;
    [SerializeField] TextMeshProUGUI newBest;

    ScoreKeeper scoreKeeper;
    AudioPlayer audioPlayer;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        
        nickname.text = PlayerPrefs.GetString("saveNickname");
        newBest.gameObject.SetActive(false);
    }

    private void Start()
    {
        lastScoreText.text = $" {scoreKeeper.GetScore()}";
        NewBest();
    }

    private void NewBest()
    {
        if (scoreKeeper.GetScore() > PlayerPrefs.GetInt("PreviousBestScore"))
        {
            PlayerPrefs.SetInt("PreviousBestScore", scoreKeeper.GetScore());
            PlayerPrefs.Save();
            newBest.gameObject.SetActive(true);
            audioPlayer.PlayNewBestClip();
        }
    }
}
