using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject dangerousPrefab;
    [SerializeField] private GameObject bonusPrefab;
    [SerializeField] private float dangerousSpawnTime;

    private float timeUntilDangerousSpawn;
    private bool bonusSpawned = false;

    private void Awake()
    {
        SetTimerUntilSpawn();
    }

    private void Update()
    {
        timeUntilDangerousSpawn -= Time.deltaTime;
        Vector3 randomSpawnPosition = new Vector3(-3.5f, Random.Range(-1f, 1f), 0);

        if (timeUntilDangerousSpawn <= 0)
        {
            Instantiate(dangerousPrefab, randomSpawnPosition, Quaternion.identity);
            if (!bonusSpawned)
            {
                Instantiate(bonusPrefab, randomSpawnPosition - new Vector3(1.2f, 0, 0), Quaternion.identity);
                bonusSpawned = true;
            }
            else
            {
                bonusSpawned = false;
            }
            SetTimerUntilSpawn();
        }

        
    }

    private void SetTimerUntilSpawn()
    {
        timeUntilDangerousSpawn = dangerousSpawnTime;
    }
    
}
