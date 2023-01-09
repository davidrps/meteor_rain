using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    public Bullet bullet;
    public ScoreScript ScoreScript;
    public GameOverScript GameOverScript;
    Rigidbody2D rb;
    SpriteRenderer sr;
    bool forceOn = false;
    float forceAmount = 10.0f;
    float torqueDirection = 0.0f;
    float torqueAmount = 0.5f;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        // Space key shoot the bullet
        if(Input.GetKeyDown (KeyCode.Space)) {
            Bullet theBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            theBullet.shoot(transform.right);
        }

        // Up or W keys apply force to move the ship
        forceOn = Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W);

        // Left or A keys rotates the ship to the left - Right or D keys rotates the ship to the right
        if(Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
            torqueDirection = 1f;
        } else if(Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
            torqueDirection = -1f;
        } else {
            torqueDirection = 0f;
        }

        // Wrap around
        wrapAroundBoundary();

        // Back to menu with escape
        if(Input.GetKey (KeyCode.Escape)) {
            GameOverScript.BackToMenu();
        }
    }

    // Function to wrap the ship to avoid to go out of screen
    void wrapAroundBoundary() {
        float x = transform.position.x;
        float y = transform.position.y;

        if(x > 8f) {x = x - 16f;}
        if(x < -8f) {x = x + 16f;}
        if(y > 5f) {y = y - 10f;}
        if(y < -5f) {y = y + 10f;}

        transform.position = new Vector2(x,y);
    }

    void FixedUpdate() {
        // Move
        if(forceOn) {
            rb.AddForce(transform.right * forceAmount);
        }

        // Rotate
        if(torqueDirection != 0) {
            rb.AddTorque(torqueDirection * torqueAmount);
        }
    }

    // Function to handle the collision of the ship with meteors
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Meteor"){
            transform.position = new Vector2(50000f, 50000f);
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            turnOffCollisions();
            Destroy(other.gameObject);
            ScoreScript.instance.LostLive();
            if (ScoreScript.lives >= 0) {
                Invoke("reset", 1f);
            }
        }
    }

    // Function to disable the collisions
    void turnOffCollisions() {
        gameObject.layer = LayerMask.NameToLayer("Ignore");
    }

    // Function to reset the position of the ship after collision
    void reset() {
        transform.position = new Vector2(0f, 0f);
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
        Invoke("turnOnCollisions", 3f);
    }

    // Function to enable the collisions
    void turnOnCollisions() {
        gameObject.layer = LayerMask.NameToLayer("Ship");
    }

    public void InitShip() {
        transform.position = new Vector2(0f, 0f);
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        Invoke("turnOnCollisions", 1f);
    }
}
