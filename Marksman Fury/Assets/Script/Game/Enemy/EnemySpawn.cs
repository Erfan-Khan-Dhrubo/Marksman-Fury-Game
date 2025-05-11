using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] private float minimumSpawnTime;
    [SerializeField] private float maximumSpawnTime;

    [SerializeField] private GameObject enemyPrefab;
    
    private float _timeUntilSpawn;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;
        if (_timeUntilSpawn <= 0)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
        
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
