using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {
    Rigidbody2D rb;
    float destroyTime = 2f;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Function to destroy the meteor after a few seconds
    void Update() {
        Destroy(gameObject, destroyTime);
    }

    // Function to destroy the meteor on colission with the bullet
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Bullet") {
            Destroy(gameObject);
            ScoreScript.instance.AddScore();
        }
    }
}
