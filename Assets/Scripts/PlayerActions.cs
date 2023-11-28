using UnityEditor;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathParticle;

    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    AudioPlayer audioPlayer;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bonus")
        {
            scoreKeeper.ModifyScore();
            audioPlayer.PlayBonusClip();
            Destroy(other.gameObject);
        }

        if (other.tag == "Enemy")
        {
            PlayDeathEffect();
            audioPlayer.PlayDestroyedClip();
            Destroy(gameObject);
            levelManager.LoadGameOver();
        }
    }

    private void PlayDeathEffect()
    {
        if(deathParticle != null)
        {
            ParticleSystem instance = Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
