using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float checkpointTimeExtension = 5f;

    GameManager gameManager;

    const String playerString = "Player";

    private void Start() 
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag(playerString))
        {
            gameManager.ModifyTime(checkpointTimeExtension);
        }
    }
}
