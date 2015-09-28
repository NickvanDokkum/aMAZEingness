using UnityEngine;
using System.Collections;

public class DeathScreen : MonoBehaviour {

    public double timer;

    void Start() {
        Invoke("BackToMenu", (float)timer);
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            BackToMenu();
        }
        else if (Input.anyKeyDown) {
            Restart();
        }
    }
    public void Restart() {
        Application.LoadLevel(Application.loadedLevel);
    }
    void BackToMenu() {
        Application.LoadLevel(0);
    }
}
