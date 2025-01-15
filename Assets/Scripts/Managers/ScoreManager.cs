using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    int currentScore = 0;

    private void Start() 
    {
        scoreText.text = currentScore.ToString();
    }

    public void ChangeScore(int amount)
    {
        currentScore += amount;
        scoreText.text = currentScore.ToString();
    }

}
