using UnityEngine;
using System.Collections;

public class DistanceMuting : MonoBehaviour {

    Transform playerTransform;
    PlaySound playSound;
    public int distance;

    void Start() {
        playSound = GetComponent<PlaySound>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    void Update() {
        if (playerTransform.position.x > transform.position.x + distance || playerTransform.position.x < transform.position.x - distance || playerTransform.position.y > transform.position.y + distance || playerTransform.position.y < transform.position.y - distance) {
            playSound.Mute(true);
        }
        else {
            playSound.Mute(false);
        }
    }
}
