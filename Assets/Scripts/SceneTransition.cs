using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Animator animator;



    private void Start()
    {
        animator = GetComponent<Animator>();
    }

}
