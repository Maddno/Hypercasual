using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private static ScoreKeeper instance;

    public const string PreviousBestSaves = "PreviousBestScore";
    public const string BestScoreSaves = "BestScore";

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private int currentScore;
    private int previousBest;
    private int bestScore;

    public int GetScore()
    {

        return currentScore;
    }

    public int GetBestScore()
    {
        bestScore = PlayerPrefs.GetInt(BestScoreSaves);
        
        return bestScore;
    }

    public void ModifyScore()
    {
        currentScore++;
        
        Mathf.Clamp(currentScore, 0, int.MaxValue);

        if (currentScore > bestScore)
        {
            PlayerPrefs.SetInt(BestScoreSaves, currentScore);
            
            PlayerPrefs.Save();
        }
    }

    public void ResetScore()
    {
        currentScore = 0;
        

    }
}
