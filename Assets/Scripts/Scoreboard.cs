using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour {
    public TMP_Text HighscoreName1;
    public TMP_Text HighscoreTxt1;
    public TMP_Text HighscoreName2;
    public TMP_Text HighscoreTxt2;
    public TMP_Text HighscoreName3;
    public TMP_Text HighscoreTxt3;
    public TMP_Text HighscoreName4;
    public TMP_Text HighscoreTxt4;
    public TMP_Text HighscoreName5;
    public TMP_Text HighscoreTxt5;

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
        HighscoreTxt1.text = highscore1.ToString();
        HighscoreName1.text = hsName1;
        HighscoreTxt2.text = highscore2.ToString();
        HighscoreName2.text = hsName2;
        HighscoreTxt3.text = highscore3.ToString();
        HighscoreName3.text = hsName3;
        HighscoreTxt4.text = highscore4.ToString();
        HighscoreName4.text = hsName4;
        HighscoreTxt5.text = highscore5.ToString();
        HighscoreName5.text = hsName5;
    }

    // Show the Scoreboard Screen
    public void ShowScoreboard() {
        gameObject.SetActive(true);
    }

    // Hide the Scoreboard Screen
    public void HideScoreboard() {
        gameObject.SetActive(false);
    }
}
