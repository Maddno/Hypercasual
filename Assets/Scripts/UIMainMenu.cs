using TMPro;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nickNameText;
    [SerializeField] private TextMeshProUGUI lastScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TMP_InputField inputNickname;
    [SerializeField] private GameObject nickNamePanel;

    ScoreKeeper scoreKeeper;
    ASyncLoader loader;

    private string nickname = "Nickname";

    private void Awake()
    {
        loader = FindObjectOfType<ASyncLoader>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        StatistickScore();

        nickNameText.text = PlayerPrefs.GetString("saveNickname");
        PlayerPrefs.SetString("saveNickname", nickname);
    }

    public void StatistickScore()
    {
        lastScoreText.text = $" {scoreKeeper.GetScore()}";
        bestScoreText.text = $" {scoreKeeper.GetBestScore()}";
    }

    

    public void NicknameSeterActive()
    {
        nickNamePanel.gameObject.SetActive(true);
    }

    public void NicknameSet()
    {
        nickname = inputNickname.text;

        nickNamePanel.gameObject.SetActive(false);

        PlayerPrefs.SetString("saveNickname", nickname);
        PlayerPrefs.Save();

        nickNameText.text = PlayerPrefs.GetString("saveNickname");
    }
}
