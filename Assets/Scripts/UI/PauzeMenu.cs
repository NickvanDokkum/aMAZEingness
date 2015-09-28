using UnityEngine;
using System.Collections;

public class PauzeMenu : MonoBehaviour {

    public GameObject pauzeMenu;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pauze();
        }
    }
    void pauze() {
        Time.timeScale = 0;
        pauzeMenu.SetActive(true);
    }
    public void Unpauze() {
        Time.timeScale = 1;
    }
    public void BackToMenu() {
        Time.timeScale = 1;
        GameObject.Find("TransitionScreen").GetComponent<Darkness>().Change(true, 0);
    }
}
