using UnityEngine;
using System.Collections;

public class HPPickup : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            other.gameObject.SendMessage("Heal", 1);
            Destroy(this.gameObject);
        }
    }
}
