using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Moving")]
    [SerializeField] AudioClip movingClip;
    [SerializeField][Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Bonus")]
    [SerializeField] AudioClip bonusClip;
    [SerializeField][Range(0f, 1f)] float damageVolume = 1f;

    [Header("Destroyed")]
    [SerializeField] AudioClip destroyedClip;
    [SerializeField][Range(0f, 1f)] float destroyedVolume = 1f;

    [Header("NewBestResult")]
    [SerializeField] AudioClip newBestClip;
    [SerializeField][Range(0f, 1f)] float newBestVolume = 1f;

    static AudioPlayer instance;

    void Awake()
    {
        ManageSingletone();
    }

    private void ManageSingletone()
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

    public void PlayMovingClip()
    {
        PlayClip(movingClip, shootingVolume);
    }

    public void PlayBonusClip()
    {
        PlayClip(bonusClip, damageVolume);
    }

    public void PlayDestroyedClip()
    {
        PlayClip(destroyedClip, destroyedVolume);
    }

    public void PlayNewBestClip()
    {
        PlayClip(newBestClip, newBestVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        Vector3 camerafPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, camerafPos, volume);
    }
}
