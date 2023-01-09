using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    Rigidbody2D rb;
    float speed = 15f;
    float destroyTime = 2f;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Shoot public function
    public void shoot(Vector2 direction) {
        rb.velocity = direction.normalized * speed;
    }

    // Function to destroy the bullet after a few seconds
    void Update() {
        Destroy(gameObject, destroyTime);
    }

    // Function to destroy the bullet on colission with the meteor
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Meteor") {
            Destroy(gameObject);
        }
    }
}
