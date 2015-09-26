using UnityEngine;
using System.Collections;

public class ResetScore : MonoBehaviour {

	// Use this for initialization
    void Start() {
        PlayerPrefs.SetInt("tileAmount", 100);
	}
}
