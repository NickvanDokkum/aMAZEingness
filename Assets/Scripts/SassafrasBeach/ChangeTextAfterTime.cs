using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeTextAfterTime : MonoBehaviour {

    public string nextText;
    public double timer;

	void Start () {
        Invoke("ChangeText", (float)timer);
	}
    void ChangeText() {
        GetComponent<Text>().text = nextText;
    }
}
