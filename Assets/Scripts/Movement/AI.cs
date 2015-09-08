using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    Transform player;
    Vector2 movementVector;
    Movement movement;

    void Awake() {
        movement = GetComponent<Movement>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void FixedUpdate() {
        Vector2 difference = player.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, difference);
        if (hit.collider.gameObject.tag == "Player") {
            Debug.Log("ATTACK");
            movementVector = difference.normalized;
        }
        else {
            movementVector = new Vector2(0,0);
        }
	}
    void Update() {
        movement.Move(movementVector);
    }
}
 