using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EddieDecay : MonoBehaviour {

    Image image;
    public Sprite[] sprites;
    int currentFrame = 0;
    public double timeBetweenFrames;
	
	void Start () {
        image = GetComponent<Image>();
        InvokeRepeating("ChangeArt", 0, (float)timeBetweenFrames);
	}
    void ChangeArt() {
        if (sprites.Length > currentFrame) {
            image.sprite = sprites[currentFrame];
        }
        currentFrame++;
    }
}
