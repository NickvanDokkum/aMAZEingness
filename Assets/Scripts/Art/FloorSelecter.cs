using UnityEngine;
using System.Collections;

public class FloorSelecter : MonoBehaviour {

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;

    int Number;
	
	void Start () {
        Number = Random.Range(0, 10);
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (Number < 6) {
            spriteRenderer.sprite = sprite1;
        }
        else if (Number < 9) {
            spriteRenderer.sprite = sprite2;
        }
        else {
            spriteRenderer.sprite = sprite3;
        }
        Destroy(this);
	}
}
