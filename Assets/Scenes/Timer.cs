using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft = 60f;
    public TMP_Text timerText;
    public GameObject gameOverUI;
    public GameObject winUI;

    private bool isGameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;
        timeLeft -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.Ceil(timeLeft).ToString();
        if (timeLeft <= 0)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        isGameOver = true;

        gameOverUI.SetActive(true);
        Time.timeScale = 0f; 
    }
    public void Win()
    {
        isGameOver = true;

        winUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
