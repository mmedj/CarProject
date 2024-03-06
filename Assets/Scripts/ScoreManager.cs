using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the UI text displaying the score
    public int score = 0; // Initial score value
    public CarMotion car; // Reference to the ScoreManager script

    void Update()
    {
        if (score > 50)
        { 
            car.nitro = 0.7f; 
        }
        else
        {
            car.nitro=0.3f;
        }


    }
    public void IncreaseScore(int amount)
    {
        score += amount/2;
        UpdateScoreText();
    }

    public void DecreaseScore(int amount)
    {
        if(score-amount/2>0){
            score -= amount/2;
        }
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}