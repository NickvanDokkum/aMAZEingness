﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public GameObject continueButton;

    void Start() {
        if (PlayerPrefs.GetInt("tileAmount") < 100) {
            continueButton.GetComponent<Button>().interactable = false;
        }
    }
    public void Continue() {
        Application.LoadLevel(2);
    }
    public void NewGame() {
        Application.LoadLevel(1);
    }
}
