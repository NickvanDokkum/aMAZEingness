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
        GameObject.Find("TransitionScreen").GetComponent<Darkness>().Change(true, Application.loadedLevel);
    }
    void BackToMenu() {
        GameObject.Find("TransitionScreen").GetComponent<Darkness>().Change(true, 0);
    }
}
