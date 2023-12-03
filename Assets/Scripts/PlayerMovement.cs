using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float moveAcceleration = 2f;
    
    PlayerInput playerInput;
    AudioPlayer audioPlayer;

    private InputAction keyboardInput;
    private InputAction touchInput;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        playerInput = GetComponent<PlayerInput>();

        keyboardInput = playerInput.actions.FindAction("Keyboard");
        touchInput = playerInput.actions.FindAction("Phone");

    }

    private void Update()
    {
        moveSpeed += moveAcceleration * Time.deltaTime;
        transform.Rotate(new Vector3(0f, 0f, moveSpeed * Time.deltaTime));
    }

    private void OnEnable()
    {
        touchInput.performed += OnTouch;
        keyboardInput.performed += OnTouch;

    }

    private void OnDisable()
    {
        touchInput.performed -= OnTouch;
        keyboardInput.performed -= OnTouch;

    }
    private void OnTouch(InputAction.CallbackContext context)
    {
        moveSpeed *= -1;
        moveAcceleration *= -1;
        audioPlayer.PlayMovingClip();
    }

}
