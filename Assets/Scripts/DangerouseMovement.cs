using UnityEngine;

public class DangerouseMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    
    private void Update()
    {
        transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
    }
}
