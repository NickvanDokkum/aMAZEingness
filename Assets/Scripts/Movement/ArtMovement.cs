using UnityEngine;
using System.Collections;

public class ArtMovement : MonoBehaviour {

    public Sprite[] sprites;
    Movement movementScript;
    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movementScript = GetComponent<Movement>();
        InvokeRepeating("ChangeMovementArt", 0, 0.25f);
    }

    void ChangeMovementArt() {
        Vector2 movement = movementScript.movementVector;
        Vector2 originalMovement = movement;
        bool moveVerticle = true;
        if (movement.y != 0) {
            if (movement.y < 0) {
                movement.y = -movement.y;
            }
            if (movement.x < 0) {
                movement.x = -movement.x;
            }
            if(movement.y < movement.x){
                moveVerticle = false;
            }
            if (moveVerticle) {
                if (originalMovement.y > 0) {
                    if (spriteRenderer.sprite == sprites[1]) {
                        spriteRenderer.sprite = sprites[2];
                    }
                    else {
                        spriteRenderer.sprite = sprites[1];
                    }
                }
                else if (originalMovement.y < 0) {
                    if (spriteRenderer.sprite == sprites[4]) {
                        spriteRenderer.sprite = sprites[5];
                    }
                    else {
                        spriteRenderer.sprite = sprites[4];
                    }
                }
            }
            else {
                if (originalMovement.x > 0) {
                    if (spriteRenderer.sprite == sprites[7]) {
                        spriteRenderer.sprite = sprites[8];
                    }
                    else {
                        spriteRenderer.sprite = sprites[7];
                    }
                }
                else if (originalMovement.x < 0) {
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
