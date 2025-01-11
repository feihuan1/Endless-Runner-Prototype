using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunkAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float ChunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;

    List<GameObject> chunks = new List<GameObject>();

    private void Start()
    {
        SpawnStartingChunks();

    }

    private void Update()
    {
        MoveChunks();
    }

    void SpawnStartingChunks()
    {
        for (int i = 0; i < startingChunkAmount; i++)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        float spawnPositionZ = CalculateSpawnPositionZ();
        Vector3 ChunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        GameObject newChunk = Instantiate(chunkPrefab, ChunkSpawnPos, quaternion.identity, chunkParent);

        //chunks[i] = newChunk; //this will crash because in C# , List is empty, index out bound, unlike JS array is default with a undefined value
        chunks.Add(newChunk);
    }

    float CalculateSpawnPositionZ()
    {
        float spawnPositionZ;

        if (chunks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            // spawnPositionZ = transform.position.z + (i * ChunkLength);
            spawnPositionZ = chunks[chunks.Count -1].transform.position.z + ChunkLength;
        }

        return spawnPositionZ;
    }

    void MoveChunks()
    {
        // foreach(GameObject chunk in chunks)
        // {
        //     chunk.transform.Translate(-transform.forward * moveSpeed * Time.deltaTime);
        // }
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunks[i].transform.Translate(-transform.forward * moveSpeed * Time.deltaTime);

            if(chunk.transform.position.z <= Camera.main.transform.position.z - ChunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
        }

 
    }
}
