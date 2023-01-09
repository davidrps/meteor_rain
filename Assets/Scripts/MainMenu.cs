using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {
    // StartGame is called when the Play button is pressed
    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        Application.Quit();
    }

    void Update() {
        if(Input.GetKey (KeyCode.Q)) {
            QuitGame();
        }
    }

}
