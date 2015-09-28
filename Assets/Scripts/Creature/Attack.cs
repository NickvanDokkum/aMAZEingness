using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public Sprite[] sprites;
    public Collider2D[] colliders;
    SpriteRenderer spriteRenderer;
    uint AttackDir;
    uint curSprite = 1;

	void Start () {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}
    public void StartAttack(uint attackDirection) {
        AttackDir = attackDirection;
        InvokeRepeating("NextSprite", 0, 0.2f);
        SendMessage("AttackStart");
        colliders[AttackDir].enabled = true;
        GetComponent<PlaySound>().StartPlaySound(2);
    }
    void StopAttack() {
        colliders[AttackDir].enabled = false;
        CancelInvoke("NextSprite");
        SendMessage("EndAttack");
    }
    void NextSprite() {
        if (curSprite >= 4) {
            curSprite = 1;
            StopAttack();
        }
        spriteRenderer.sprite = sprites[(AttackDir * 4) + curSprite - 1];
        curSprite++;
    }
}
