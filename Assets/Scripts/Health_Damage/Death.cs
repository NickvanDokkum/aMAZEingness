using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;
    uint frame = 0;
    bool finished = false;

	public void Die () {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Destroy(GetComponent<AI>());
        Destroy(GetComponent<PlayerController>());
        Destroy(GetComponent<Health>());
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(GetComponent<ArtMovement>());
        if (gameObject.tag == "Player") {
            Destroy(GetComponent<Attack>());
        }
        GetComponent<PlaySound>().StartPlaySound(1);
        InvokeRepeating("ChangeArt", 0, 0.2f);
	}
    void ChangeArt() {
        if (frame >= sprites.Length) {
            spriteRenderer.sprite = null;
            if (finished == true) {
                if (tag == "Player") {
                    GameObject.Find("GameOverScreen").GetComponent<EnableDeathScreen>().EnableTheGameobject();
                }
                else {
                    Destroy(this.gameObject);
                }
            }
            finished = true;
        }
        else {
            spriteRenderer.sprite = sprites[frame];
            frame++;
        }
    }
}
