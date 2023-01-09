using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {
    // Show the Credits Screen
    public void ShowCredits() {
        gameObject.SetActive(true);
    }

    // Hide the Credits Screen
    public void HideCredits() {
        gameObject.SetActive(false);
    }
}
