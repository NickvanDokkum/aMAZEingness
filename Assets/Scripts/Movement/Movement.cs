using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    int speed = 3;
    float moveHorizontal;
    float moveVerticle;

    void Update (){
        moveHorizontal = 0;
        moveVerticle = 0;
        if (Input.GetKey(KeyCode.W)) {
            moveVerticle += 1;
            Debug.Log("W");
        }
        if (Input.GetKey(KeyCode.S)) {
            moveVerticle -= 1;
            Debug.Log("S");
        }
        if (Input.GetKey(KeyCode.A)) {
            moveHorizontal -= 1;
            Debug.Log("A");
        }
        if (Input.GetKey(KeyCode.D)) {
            moveHorizontal += 1;
            Debug.Log("eddie loves the ...");
        }
        if (Input.GetKey(KeyCode.Space)) {
            Debug.Log("Roll");
        }
        if (moveHorizontal != 0) {
            Debug.Log("moveHorizontal");
            if (moveVerticle != 0) {
                moveHorizontal /= 2;
            }
            transform.Translate(Vector2.right * Time.deltaTime * moveHorizontal * speed);
        }
        if (moveVerticle != 0) {
            Debug.Log("verticle");
            if (moveHorizontal != 0) {
                moveVerticle /= 2;
            }
            transform.Translate(Vector2.up * Time.deltaTime * moveVerticle * speed);
        }
    }
}
