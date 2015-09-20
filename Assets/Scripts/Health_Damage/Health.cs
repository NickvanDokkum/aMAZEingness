using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int HP = 5;
    HPbar hpbar;

    void Start() {
        if (tag == "Player") {
            hpbar = GameObject.Find("HP").GetComponent<HPbar>();
        }
    }

    void Damage(int damage) {
        HP -= damage;
        Debug.Log(gameObject.name + HP);
        if (HP <= 0) {
            Death();
        }
        if (tag == "Player") {
            hpbar.ChangeHP(true);
        }
    }
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy" && gameObject.tag == "Player"){
            Damage(1);
            Debug.Log(other.gameObject.name);
        }
        else if (other.gameObject.tag == "HPpickup" && HP < 5) {
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
