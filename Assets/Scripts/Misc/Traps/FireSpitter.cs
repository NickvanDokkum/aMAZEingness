using UnityEngine;
using System.Collections;

public class FireSpitter : MonoBehaviour {

    public int curSprite = 0;
    SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    bool curUp = true;
    BoxCollider2D collider;

    void Start() {
        InvokeRepeating("ChangeFire", 0.25f, 0.25f);
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
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
            collider.enabled = false;
        }
        else {
            collider.enabled = true;
        }
        if (curSprite >= 0) {
            spriteRenderer.sprite = sprites[curSprite];
        }
    }
}
