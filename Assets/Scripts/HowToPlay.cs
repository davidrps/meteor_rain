using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour {
    // Show the Credits Screen
    public void ShowHowToPlay() {
        gameObject.SetActive(true);
    }

    // Hide the Credits Screen
    public void HideHowToPlay() {
        gameObject.SetActive(false);
    }
}
