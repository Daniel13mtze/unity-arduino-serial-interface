using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        spawnObstacle();
        SpawnCoin();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    public GameObject obstaclePrefab;

    void spawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(3,7);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public GameObject coinPrefab;

    void SpawnCoin()
    {
        int coinSpawnIndex = Random.Range(23, 25);
        Transform spawnPoint = transform.GetChild(coinSpawnIndex).transform;
        Instantiate(coinPrefab, spawnPoint.position, Quaternion.identity, transform);

    }

}
