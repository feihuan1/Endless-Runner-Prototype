using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject CoinPrefab;
    [SerializeField] float appleSpawnChance = 0.2f;
    [SerializeField] float coinSpawnChance = 0.4f;
    [SerializeField] float coinSaperationLength = 2f;

    [SerializeField] float[] lanes = { -2.5f, 0, 2.5f };

    List<int> avaliableLanes = new List<int> { 0, 1, 2 };

    private void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoin();
    }

    private void SpawnFences()
    {
        int fenceToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fenceToSpawn; i++)
        {
            if (avaliableLanes.Count <= 0) break;

            int selectedLane = SelectLane();

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    void SpawnApple()
    {   
        if (avaliableLanes.Count <= 0 || Random.value > appleSpawnChance) return;

        int selectedLane = SelectLane();

        Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform);
    }
    void SpawnCoin()
    {   
        if (avaliableLanes.Count <= 0 || Random.value > coinSpawnChance) return;

        int selectedLane = SelectLane();

        int maxCoinToSpawn = 6;
        int coinsToSpawn = Random.Range(1, maxCoinToSpawn);

        float topOfChunkZPos = transform.position.z + (coinSaperationLength * 2f);

        for (int i = 0; i < coinsToSpawn; i++)
        {
            float spawnpositionZ = topOfChunkZPos - (i * coinSaperationLength);
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, spawnpositionZ);
            Instantiate(CoinPrefab, spawnPosition, Quaternion.identity, this.transform);
        }


    }

    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, avaliableLanes.Count);
        int selectedLane = avaliableLanes[randomLaneIndex];
        avaliableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }

}
