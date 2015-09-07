using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    int speed = 3;
    
    public void Move(float hor, float ver) {
        transform.Translate(Vector2.up * Time.deltaTime * ver * speed);
        transform.Translate(Vector2.right * Time.deltaTime * hor * speed);
    }
}
