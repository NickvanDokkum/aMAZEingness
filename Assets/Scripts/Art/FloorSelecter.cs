using UnityEngine;
using System.Collections;

public class FloorSelecter : MonoBehaviour {

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public int sprite1Chance;
    public int sprite2Chance;

    int Number;
	
	void Start () {
        Number = Random.Range(0, 10);
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (Number < sprite1Chance) {
            spriteRenderer.sprite = sprite1;
        }
        else if (Number < sprite2Chance) {
            spriteRenderer.sprite = sprite2;
        }
        else {
            spriteRenderer.sprite = sprite3;
        }
        Destroy(this);
	}
}
