using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Darkness : MonoBehaviour {

    Image image;
    bool change = false;
    bool dark;
    int sceneInt;

	void Start () {
        image = GetComponent<Image>();
        Change(false, 0);
	}
	
	void FixedUpdate () {
        if (change) {
            if (dark) {
                image.color = new Color(0, 0, 0, image.color.a + Time.deltaTime * 10);
                if (image.color.a >= 1) {
                    Time.timeScale = 1;
                    Application.LoadLevel(sceneInt);
                }
            }
            else {
                image.color = new Color(0, 0, 0, image.color.a - Time.deltaTime * 10);
                if (image.color.a <= 0) {
                    Time.timeScale = 1;
                    change = false;
                }
            }
        }
	}
    public void Change(bool isItDark, int scene) {
        dark = isItDark;
        change = true;
        sceneInt = scene;
        Time.timeScale = 0.1f;
    }
}
