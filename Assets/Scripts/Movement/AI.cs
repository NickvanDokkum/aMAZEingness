using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    Transform player;
    Vector2 movementVector;
    Movement movement;
    public int Range;

    void Start() {
        movement = GetComponent<Movement>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        Vector2 difference = player.position - transform.position;
        if (difference.x < 5 && difference.x > -5 && difference.y < 5 && difference.y > -5) {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate() {
        Vector2 difference = player.position - transform.position;
        if (difference.x < 5 && difference.x > -5 && difference.y < 5 && difference.y > -5) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, difference);
            if (hit.collider.gameObject.tag == "Player") {
                Debug.Log("ATTACK");
                movementVector = difference.normalized;
            }
            else {
                movementVector = new Vector2(0, 0);
            }
        }
        else {
            movementVector = new Vector2(0, 0);
        }
    }
    void Update() {
        movement.Move(movementVector);
    }
}
