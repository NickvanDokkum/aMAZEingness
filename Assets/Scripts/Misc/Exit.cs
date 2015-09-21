using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            PlayerPrefs.SetInt("tileAmount", PlayerPrefs.GetInt("tileAmount") + 50);
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
