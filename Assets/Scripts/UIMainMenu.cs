using TMPro;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nickNameText;
    [SerializeField] private TextMeshProUGUI lastScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TMP_InputField inputNickname;
    [SerializeField] private GameObject nickNamePanel;

    public const string SavedNickname = "saveNickname";

    ScoreKeeper scoreKeeper;
    ASyncLoader loader;

    private string nickname;

    private void Awake()
    {
        loader = FindObjectOfType<ASyncLoader>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        StatistickScore();
        EmptyNicknameCheck();
    }

    private void StatistickScore()
    {
        lastScoreText.text = $" {scoreKeeper.GetScore()}";
        bestScoreText.text = $" {scoreKeeper.GetBestScore()}";
    }

    public void NicknameSeterActive()
    {
        nickNamePanel.gameObject.SetActive(true);
        nickNameText.gameObject.SetActive(false);
    }

    public void NicknameSet()
    {
        if(string.IsNullOrEmpty(inputNickname.text))
        {
            PlayerPrefs.SetString(SavedNickname, "Nickname");
        }
        else
        {
            PlayerPrefs.SetString(SavedNickname, inputNickname.text);
            PlayerPrefs.Save();
        }

        nickNameText.text = PlayerPrefs.GetString(SavedNickname);

        nickNamePanel.gameObject.SetActive(false);
        nickNameText.gameObject.SetActive(true);
    }

    private void EmptyNicknameCheck()
    {
        if (string.IsNullOrEmpty(PlayerPrefs.GetString(SavedNickname)))
        {
            nickNameText.text = "Nickname";
        }
        else
        {
            nickNameText.text = PlayerPrefs.GetString(SavedNickname);
        }
    }
}
