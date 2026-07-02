using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public static GameManager inst;
    public TextMeshProUGUI scoreText;
    
    public void incrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    } 
    private void Awake()
    {
        inst = this;
    }
}
