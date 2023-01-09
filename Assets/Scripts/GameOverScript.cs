using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScript : MonoBehaviour {
    public TMP_Text finalScoreText;

    int finalScore = 0;

    int highscore1 = 0;
    int highscore2 = 0;
    int highscore3 = 0;
    int highscore4 = 0;
    int highscore5 = 0;
    string hsName1 = "Name";
    string hsName2 = "Name";
    string hsName3 = "Name";
    string hsName4 = "Name";
    string hsName5 = "Name";

    // Start is called before the first frame update
    void Start() {
        highscore1 = PlayerPrefs.GetInt("highscore1", 0);
        highscore2 = PlayerPrefs.GetInt("highscore2", 0);
        highscore3 = PlayerPrefs.GetInt("highscore3", 0);
        highscore4 = PlayerPrefs.GetInt("highscore4", 0);
        highscore5 = PlayerPrefs.GetInt("highscore5", 0);
        hsName1 = PlayerPrefs.GetString("highscoreName1", "Name");
        hsName2 = PlayerPrefs.GetString("highscoreName2", "Name");
        hsName3 = PlayerPrefs.GetString("highscoreName3", "Name");
        hsName4 = PlayerPrefs.GetString("highscoreName4", "Name");
        hsName5 = PlayerPrefs.GetString("highscoreName5", "Name");
    }

    public void Setup(int score) {
        highscore5 = PlayerPrefs.GetInt("highscore5", 0);
        gameObject.SetActive(true);
        finalScoreText.text = "Final Score: " + score.ToString();
        if(score >= highscore5) {
            finalScore = score;
            transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    public void SaveHighscore(string name) {
        if(finalScore >= highscore1) {
            PlayerPrefs.SetInt("highscore5", highscore4);
            PlayerPrefs.SetInt("highscore4", highscore3);
            PlayerPrefs.SetInt("highscore3", highscore2);
            PlayerPrefs.SetInt("highscore2", highscore1);
            PlayerPrefs.SetInt("highscore1", finalScore);
            PlayerPrefs.SetString("highscoreName5", hsName4);
            PlayerPrefs.SetString("highscoreName4", hsName3);
            PlayerPrefs.SetString("highscoreName3", hsName2);
            PlayerPrefs.SetString("highscoreName2", hsName1);
            PlayerPrefs.SetString("highscoreName1", name);
        } else if(finalScore >= highscore2) {
            PlayerPrefs.SetInt("highscore5", highscore4);
            PlayerPrefs.SetInt("highscore4", highscore3);
            PlayerPrefs.SetInt("highscore3", highscore2);
            PlayerPrefs.SetInt("highscore2", finalScore);
            PlayerPrefs.SetString("highscoreName5", hsName4);
            PlayerPrefs.SetString("highscoreName4", hsName3);
            PlayerPrefs.SetString("highscoreName3", hsName2);
            PlayerPrefs.SetString("highscoreName2", name);          
        } else if(finalScore >= highscore3) {
            PlayerPrefs.SetInt("highscore5", highscore4);
            PlayerPrefs.SetInt("highscore4", highscore3);
            PlayerPrefs.SetInt("highscore3", finalScore);
            PlayerPrefs.SetString("highscoreName5", hsName4);
            PlayerPrefs.SetString("highscoreName4", hsName3);
            PlayerPrefs.SetString("highscoreName3", name);
        } else if(finalScore >= highscore4) {
            PlayerPrefs.SetInt("highscore5", highscore4);
            PlayerPrefs.SetInt("highscore4", finalScore);
            PlayerPrefs.SetString("highscoreName5", hsName4);
            PlayerPrefs.SetString("highscoreName4", name);
        } else {
            PlayerPrefs.SetInt("highscore5", finalScore);
            PlayerPrefs.SetString("highscoreName5", name);
        }
    }

    public void HideGameOver() {
        gameObject.SetActive(false);
        finalScoreText.text = "Final Score: 0";
    }

    public void BackToMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
