using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public GameObject continueButton;

    void Start() {
        Screen.SetResolution(800, 500, false);
        if (PlayerPrefs.GetInt("tileAmount") <= 100) {
            continueButton.GetComponent<Button>().interactable = false;
        }
    }
    public void Continue() {
        GameObject.Find("TransitionScreen").GetComponent<Darkness>().Change(true, 2);
    }
    public void NewGame() {
        GameObject.Find("TransitionScreen").GetComponent<Darkness>().Change(true, 1);
    }
}
