using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Movement movement;

    void Awake() {
        movement = GetComponent<Movement>();
    }

    float moveHorizontal;
    float moveVerticle;

    void Update() {
        moveHorizontal = 0;
        moveVerticle = 0;
        if (Input.GetKey(KeyCode.W)) {
            moveVerticle += 1;
        }
        if (Input.GetKey(KeyCode.S)) {
            moveVerticle -= 1;
        }
        if (Input.GetKey(KeyCode.A)) {
            moveHorizontal -= 1;
        }
        if (Input.GetKey(KeyCode.D)) {
            moveHorizontal += 1;
        }
        if (Input.GetKey(KeyCode.Space)) {
        }
        if (moveHorizontal != 0) {
            if (moveVerticle != 0) {
                moveHorizontal /= 1.35f;
            }

        }
        if (moveVerticle != 0) {
            if (moveHorizontal != 0) {
                moveVerticle /= 1.35f;
            }
        }
        Vector2 movementVector = new Vector2(moveHorizontal, moveVerticle);
        movement.Move(movementVector);
    }
}
