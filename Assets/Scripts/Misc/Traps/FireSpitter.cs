using UnityEngine;
using System.Collections;

public class FireSpitter : MonoBehaviour {

    public int curSprite = 0;
    SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    bool curUp = true;
    BoxCollider2D theCollider;

    void Start() {
        if (curSprite == 0) {
            curSprite = Random.Range(-3, 4);
            if (curSprite > 0) {
                curUp = false;
            }
        }
        InvokeRepeating("ChangeFire", 0.25f, 0.25f);
        spriteRenderer = GetComponent<SpriteRenderer>();
        theCollider = GetComponent<BoxCollider2D>();
    }

    void ChangeFire() {
        if (curUp) {
            curSprite++;
            if (curSprite == 3) {
                curUp = false;
            }
        }
        else {
            curSprite--;
            if (curSprite == -3) {
                curUp = true;
            }
        }
        if (curSprite < 1) {
            theCollider.enabled = false;
        }
        else {
            theCollider.enabled = true;
        }
        if (curSprite >= 0) {
            spriteRenderer.sprite = sprites[curSprite];
        }
    }
}
