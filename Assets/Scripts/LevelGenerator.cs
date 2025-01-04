using Unity.Mathematics;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunkAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float ChunkLength = 10f;

    private void Start() {

        for(int i = 0; i < startingChunkAmount; i++)
        {
            Vector3 ChunkSpawnPos = new Vector3(transform.position.x,transform.position.y,transform.position.z + i * ChunkLength);
            Instantiate(chunkPrefab, ChunkSpawnPos, quaternion.identity, chunkParent);
        }

    }
}
