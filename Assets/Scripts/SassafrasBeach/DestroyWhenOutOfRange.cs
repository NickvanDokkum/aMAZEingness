using UnityEngine;
using System.Collections;

public class DestroyWhenOutOfRange : MonoBehaviour {

    Transform player;
    bool armed = false;
    public float timer = 2.5f;

    void Start() {
        player = GameObject.FindWithTag("Player").transform;
    }
    void Update() {
        if (player.position.x > transform.position.x + 10 ||  player.position.x < transform.position.x - 10 || player.position.y > transform.position.y + 10 || player.position.y < transform.position.y - 10) {
            if (armed == true) {
                if (timer < 0) {
                    Destroy(this.gameObject);
                }
                else {
                    timer -= Time.deltaTime;
                }
            }
        }
        else {
            armed = true;
        }
    }
}
