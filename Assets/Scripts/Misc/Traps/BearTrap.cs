using UnityEngine;
using System.Collections;

public class BearTrap : MonoBehaviour {

    public Sprite[] sprites;
    bool closing = false;
    Transform player;
    public int range = 4;
    bool armed = false;
    public GameObject bear;
    PlaySound playSound;

    void Start() {
        player = GameObject.FindWithTag("Player").transform;
        playSound = GetComponent<PlaySound>();
    }
    void Update() {
        Vector3 difference = player.position - gameObject.transform.position;
        if (difference.x < range && difference.x > -range && difference.y > -range && difference.y < range) {
            armed = true;
        }
        else if(armed == true) {
            Vector3 spawnPos = gameObject.transform.position;
            spawnPos.z -= 5;
            Instantiate(bear, spawnPos, transform.rotation);
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy") {
            TrapClosing();
            other.gameObject.SendMessage("Damage", 1);
            playSound.StartPlaySound(0);
        }
    }
    void TrapClosing() {
        GetComponent<SpriteRenderer>().sprite = sprites[0];
        if (closing == true) {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(this);
        }
        Invoke("TrapClosing", 0.1f);
        closing = true;
    }
}
