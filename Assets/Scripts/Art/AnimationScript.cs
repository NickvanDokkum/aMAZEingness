using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {

    public Sprite[] sprites;
    public double timeBetweenFrames;
    SpriteRenderer spriteRenderer;
    int currentSprite = 0;
    bool up = true;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("ChangeArt", (float)timeBetweenFrames / 2, (float)timeBetweenFrames);
    }

	void ChangeArt () {
        if (up) {
            if (currentSprite < sprites.Length - 1) {
                currentSprite++;
            }
            else {
                up = false;
                currentSprite--;
            }
        }
        else {
            if (currentSprite != 0) {
                currentSprite--;
            }
            else {
                up = true;
                currentSprite++;
            }
        }
        spriteRenderer.sprite = sprites[currentSprite];
	}
}
