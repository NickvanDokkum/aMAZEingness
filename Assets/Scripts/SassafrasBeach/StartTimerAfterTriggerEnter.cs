using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartTimerAfterTriggerEnter : MonoBehaviour {

    public string nextText;
    public double timer;

    void OnTriggerEnter2D() {
        Invoke("ChangeText", (float)timer);
        Destroy(GetComponent<Collider2D>());
    }
    void ChangeText() {
        GetComponent<Text>().text = nextText;
    }
}
