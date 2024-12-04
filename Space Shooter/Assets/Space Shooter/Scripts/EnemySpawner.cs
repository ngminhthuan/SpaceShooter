using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] int maxEnemies = 10;
    [SerializeField] int currentEnemyCount = 0;
    public int EnemyAmount => currentEnemyCount; 

    public static EnemySpawner Instance { get; private set; }
    [SerializeField] List<GameObject> enemies = new List<GameObject>();
    private void Awake()
    {
        // Check if an instance already exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void StartSpawn()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
        currentEnemyCount = maxEnemies;
    }

    void SpawnEnemy()
    {
        if (currentEnemyCount == 0)
        {
            CancelInvoke(nameof(SpawnEnemy));
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        enemies.Add(Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity));
        currentEnemyCount--;
    }

    public void EnemyDestroyed()
    {
        GameView.Instance.ReloadView();
        if(currentEnemyCount == 0)
        {
            GameView.Instance.gameObject.SetActive(false);
            ResultView.Instance.gameObject.SetActive(true);
            ResultView.Instance.text.text = "You Win";
        }
    }

    public void ResetStage()
    {
        CancelInvoke(nameof(SpawnEnemy));
        enemies.ForEach(enemy => Destroy(enemy));
        enemies = new List<GameObject>();
        StartSpawn();
    }
}
