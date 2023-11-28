using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float moveAcceleration = 2f;

    AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("enter"))
        {
            moveSpeed *= -1;
            moveAcceleration *= -1;
            audioPlayer.PlayMovingClip();
        }

        moveSpeed += moveAcceleration * Time.deltaTime;
        transform.Rotate(new Vector3(0f, 0f, moveSpeed * Time.deltaTime));
    }
}
