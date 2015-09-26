using UnityEngine;
using System.Collections;

public class ArtMovement : MonoBehaviour {

    public Sprite[] sprites;
    Movement movementScript;
    SpriteRenderer spriteRenderer;
    Vector2 lastMovement;
    public bool stop = false;

    void Start() {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        movementScript = GetComponent<Movement>();
        spriteRenderer.sprite = sprites[Random.Range(0, 4) * 3];
        InvokeRepeating("ChangeMovementArt", 0.25f, 0.25f);
    }

    void Update() {
        if (lastMovement != movementScript.movementVector) {
            RestartMovementArt();
        }
    }
    void RestartMovementArt() {
        CancelInvoke("ChangeMovementArt");
        InvokeRepeating("ChangeMovementArt", 0, 0.25f);
        lastMovement = movementScript.movementVector;
    }
    void AttackStart() {
        stop = true;
    }
    void EndAttack() {
        stop = false;
        RestartMovementArt();
    }

    void ChangeMovementArt() {
        if (!stop) {
            Vector2 movement = movementScript.movementVector;
            Vector2 originalMovement = movement;
            bool moveVerticle = true;
            if (movement.y != 0 || movement.x != 0) {
                if (movement.y < 0) {
                    movement.y = -movement.y;
                }
                if (movement.x < 0) {
                    movement.x = -movement.x;
                }
                if (movement.y < movement.x) {
                    moveVerticle = false;
                }
                if (moveVerticle) {
                    if (originalMovement.y > 0) {       //up
                        if (spriteRenderer.sprite == sprites[1]) {
                            spriteRenderer.sprite = sprites[2];
                        }
                        else {
                            spriteRenderer.sprite = sprites[1];
                        }
                    }
                    else if (originalMovement.y < 0) {  //down
                        if (spriteRenderer.sprite == sprites[4]) {
                            spriteRenderer.sprite = sprites[5];
                        }
                        else {
                            spriteRenderer.sprite = sprites[4];
                        }
                    }
                }
                else {
                    if (originalMovement.x > 0) {       //right
                        if (spriteRenderer.sprite == sprites[7]) {
                            spriteRenderer.sprite = sprites[8];
                        }
                        else {
                            spriteRenderer.sprite = sprites[7];
                        }
                    }
                    else if (originalMovement.x < 0) {  //left
                        if (spriteRenderer.sprite == sprites[10]) {
                            spriteRenderer.sprite = sprites[11];
                        }
                        else {
                            spriteRenderer.sprite = sprites[10];
                        }
                    }
                }
            }
            else {
                if (spriteRenderer.sprite == sprites[1] || spriteRenderer.sprite == sprites[2]) {
                    spriteRenderer.sprite = sprites[0];
                }
                else if (spriteRenderer.sprite == sprites[4] || spriteRenderer.sprite == sprites[5]) {
                    spriteRenderer.sprite = sprites[3];
                }
                else if (spriteRenderer.sprite == sprites[7] || spriteRenderer.sprite == sprites[8]) {
                    spriteRenderer.sprite = sprites[6];
                }
                else if (spriteRenderer.sprite == sprites[10] || spriteRenderer.sprite == sprites[11]) {
                    spriteRenderer.sprite = sprites[9];
                }
            }
        }
    }
}
