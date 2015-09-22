using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int HP = 5;
    HPbar hpbar;
    bool vulnerable = true;

    void Start() {
        if (tag == "Player") {
            hpbar = GameObject.Find("HP").GetComponent<HPbar>();
        }
    }

    void Damage(int damage) {
        if (vulnerable) {
            HP -= damage;
            if (HP <= 0) {
                Death();
            }
            if (tag == "Player") {
                hpbar.ChangeHP(true);
            }
            vulnerable = true;
            Invoke("RemoveGodMode", 0.25f);
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

    void Death() {
        if (tag != "Player") {
            Destroy(this.gameObject);
            Destroy(this);
        }
        else {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
