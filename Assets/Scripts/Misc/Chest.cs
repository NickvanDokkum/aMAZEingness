using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

    public Sprite[] sprites;
    bool opening = false;
    public GameObject Pickup;

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            OpenChest();
        }
    }
    void OpenChest() {
        GetComponent<SpriteRenderer>().sprite = sprites[0];
        if (opening == true) {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
            Destroy(GetComponent<BoxCollider2D>());
            Instantiate(Pickup, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(this);
        }
        Invoke("OpenChest", 0.25f);
        opening = true;
    }
}
