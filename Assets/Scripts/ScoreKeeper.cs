using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private static ScoreKeeper instance;

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
    private int bestScore;

    public int GetScore()
    {
        return currentScore;
    }

    public int GetBestScore()
    {
        if(currentScore > bestScore)
        {
            PlayerPrefs.SetInt("saveScore", currentScore);
            PlayerPrefs.Save();
        }

        bestScore = PlayerPrefs.GetInt("saveScore");

        return bestScore;
    }

    public void ModifyScore()
    {
        currentScore++;
        
        Mathf.Clamp(currentScore, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}
