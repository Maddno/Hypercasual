using Unity.VisualScripting;
using UnityEngine;


public class EnemyCleaner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cleaner")
        {
            Destroy(this.GameObject());
        }
    }
}
