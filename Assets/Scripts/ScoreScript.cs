using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour {
    public static ScoreScript instance;

    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public TMP_Text livesText;
    public GameOverScript GameOverScript;
    public Ship Ship;
    public MeteorSpawner MeteorSpawner;
    
    int score = 0;
    int highscore = 0;
    public int lives = 3;
    
    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        highscore = PlayerPrefs.GetInt("highscore1", 0);
        scoreText.text = "Score: " + score.ToString();
        highscoreText.text = "Highscore: " + highscore.ToString();
        livesText.text = "Lives: " + lives.ToString();
    }

    // Add score - Store high score
    public void AddScore() {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
        if (highscore < score)
            highscore = score;
            highscoreText.text = "Highscore: " + highscore.ToString();
    }

    // Lost lives
    public void LostLive() {
        lives -= 1;
        if (lives < 0) {
            GameOver();
        } else {
            livesText.text = "Lives: " + lives.ToString();
        }
    }

    public void GameOver() {
        CancelInvoke("spawn");
        GameOverScript.Setup(score);
    }

    public void RestartGame() {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
        lives = 3;
        livesText.text = "Lives: " + lives.ToString();
        highscoreText.text = "Highscore: " + highscore.ToString();
        Ship.InitShip();
        InvokeRepeating("spawn", 0f, MeteorSpawner.spawnRate);
        GameOverScript.HideGameOver();
    }
}
