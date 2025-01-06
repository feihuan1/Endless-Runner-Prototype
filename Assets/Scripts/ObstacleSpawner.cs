using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]GameObject obstaclePrefab;
    [SerializeField]float obstacleSpawnTime = 1f;

    int numberOfObstacle = 0;

    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (numberOfObstacle < 5)
        {
            yield return new WaitForSeconds(obstacleSpawnTime);

            Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
            numberOfObstacle++;

        }
    }
}
