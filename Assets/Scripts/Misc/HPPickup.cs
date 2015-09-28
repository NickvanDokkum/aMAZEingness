using UnityEngine;
using System.Collections;

public class HPPickup : MonoBehaviour {

    PlaySound playSound;

    void Start() {
        playSound = GetComponent<PlaySound>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            other.gameObject.SendMessage("Heal", 1);
            playSound.StartPlaySound(0);
            Invoke("Destroy", playSound.audioFiles[0].length);
            Destroy(GetComponent<BoxCollider2D>());
            GetComponent<SpriteRenderer>().sprite = null;
        }
    }
    void Destroy() {
        Destroy(this.gameObject);
    }
}
