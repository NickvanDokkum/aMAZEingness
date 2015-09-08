using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPbar : MonoBehaviour {

    Image image;
    public Sprite[] sprites;
    int HP = 4;

    void Start() {
        image = GetComponent<Image>();
    }

    public void ChangeHP(bool damage) {
        if (damage) {
            HP -= 1;
        }
        else {
            HP += 1;
        }
        image.sprite = sprites[HP];
    }
}
