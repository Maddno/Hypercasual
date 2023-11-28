using UnityEngine;

public class BonusRotating : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, moveSpeed * Time.deltaTime));
    }
}
