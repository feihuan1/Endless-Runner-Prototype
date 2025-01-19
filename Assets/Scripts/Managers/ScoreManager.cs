using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text scoreText;

    int currentScore = 0;

    private void Start() 
    {
        scoreText.text = currentScore.ToString();
        Debug.Log(gameManager.IsGameOver);
    }
 
    public void ChangeScore(int amount)
    {
        // if(gameManager.ReturnGameOver()) return;
        if(gameManager.IsGameOver) return;

        currentScore += amount;
        scoreText.text = currentScore.ToString();
    }

}
