using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Movement movement;
    bool attacking = false;
    Attack attack;

    void Awake() {
        movement = GetComponent<Movement>();
        attack = GetComponent<Attack>();
    }

    float moveHorizontal;
    float moveVerticle;

    void FixedUpdate() {
        if (!attacking) {
            if(Input.GetKey(KeyCode.UpArrow)){
                Attack(0);
            }
            else if(Input.GetKey(KeyCode.RightArrow)){
                Attack(1);
            }
            else if (Input.GetKey(KeyCode.DownArrow)) {
                Attack(2);
            }
            else if(Input.GetKey(KeyCode.LeftArrow)){
                Attack(3);
            }
        }
        if(!attacking){
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
    void Attack(uint attackDirection) {
        attacking = true;
        attack.StartAttack(attackDirection);

    }
    public void EndAttack() {
        attacking = false;
    }
}
