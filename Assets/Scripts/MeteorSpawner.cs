using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {
    public Meteor meteor;
    public float spawnRate = 2.0f;

    void Start() {
        InvokeRepeating("spawn", 0f, spawnRate);
    }

    // Spawner function for meteors
    void spawn() {
        // get spawn point
        Vector2 spawnPoint;
        spawnPoint = new Vector2(Random.Range(-8f, 8f), 5f);
        Meteor theMeteor = Instantiate(meteor, spawnPoint, Quaternion.identity);
    }
}
