using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int HP = 5;
    HPbar hpbar;
    PlaySound playSound;
    bool vulnerable = true;
    bool changedColor = false;
    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
        if (tag == "Player") {
            hpbar = GameObject.Find("HP").GetComponent<HPbar>();
        }
        playSound = GetComponent<PlaySound>();
    }

    void Damage(int damage) {
        if (vulnerable) {
            HP -= damage;
            if (HP <= 0) {
                Death();
            }
            else {
                ChangeColor();
                Invoke("ChangeColor", 0.125f);
            }
            playSound.StartPlaySound(0);
            vulnerable = false;
            Invoke("RemoveGodMode", 0.25f);
            if (tag == "Player") {
                hpbar.ChangeHP(true);
            }
        }
    }
    void ChangeColor() {
        if (!changedColor) {
            spriteRenderer.color = new Color(1, 0.5f, 0.5f, 1);
            changedColor = true;
        }
        else {
            spriteRenderer.color = new Color(1, 1, 1, 1);
            changedColor = false;
        }
    }
    void Heal(int healing) {
        if (HP != 5) {
            HP += healing;
            if (HP > 5) {
                HP = 5;
            }
            else if(tag == "Player") {
                hpbar.ChangeHP(false);
            }
        }
    }
    void RemoveGodMode() {
        vulnerable = true;
    }
    void OnCollisionEnter2D(Collision2D other) {
        if ((other.gameObject.tag == "Enemy" && gameObject.tag == "Player") || other.gameObject.tag == "Trap") {
            Damage(1);
        }
        else if (other.gameObject.tag == "HPpickup" && HP < 5 && gameObject.tag == "Player") {
            hpbar.ChangeHP(false);
            HP++;
            Destroy(other.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (gameObject.tag == "Enemy" && other.gameObject.tag == "Attack") {
            Damage(1);
        }
    }

    void Death() {
        gameObject.GetComponent<Death>().Die();
    }
}
