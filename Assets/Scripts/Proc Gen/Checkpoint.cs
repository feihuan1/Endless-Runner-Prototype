using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float checkpointTimeExtension = 5f;
    [SerializeField] float obstacleDecreaseTimeAmount = 0.2f;

    GameManager gameManager;
    ObstacleSpawner obstacleSpawner;

    const String playerString = "Player";

    private void Start() 
    {
        gameManager = FindFirstObjectByType<GameManager>();
        obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag(playerString))
        {
            gameManager.ModifyTime(checkpointTimeExtension);
            obstacleSpawner.DecreaseObstacleSpawnTime(obstacleDecreaseTimeAmount);
        }
    }
}
