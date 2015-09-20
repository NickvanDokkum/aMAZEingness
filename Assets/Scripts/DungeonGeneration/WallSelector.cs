using UnityEngine;
using System.Collections;

public class WallSelector : MonoBehaviour {

    public Sprite[] wallSprites;
    SpawnDungeonTiles script;
    bool up = false;
    bool down = false;
    bool left = false;
    bool right = false;

    void Awake() {
        script = GameObject.Find("DungeonGenerator").GetComponent<SpawnDungeonTiles>();
        if (!script.PlaceFree(new Vector2(transform.position.x, transform.position.y))) {
            Destroy(this.gameObject);
        }
        else {
            script.AddCoord(new Vector2(transform.position.x, transform.position.y));
        }
    }
    void Start() {
        Vector2 dir = transform.position;
        dir.y += 2;
        if (WallPositionCheck(dir)) {
            up = true;
        }
        dir.y -= 4;
        if (WallPositionCheck(dir)) {
            down = true;
        }
        dir.y += 2;
        dir.x += 2;
        if (WallPositionCheck(dir)) {
            right = true;
        }
        dir.x -= 4;
        if (WallPositionCheck(dir)) {
            left = true;
        }
        if (left) {
            if (up) {
                if (right) {
                    GetComponent<SpriteRenderer>().sprite = wallSprites[4];
                }
                else if (down) {
                    GetComponent<SpriteRenderer>().sprite = wallSprites[Random.Range(0, 4)];
                }
                else {
                    GetComponent<SpriteRenderer>().sprite = wallSprites[1];
                }
            }
            else if (right) {
                if (down) {
                    GetComponent<SpriteRenderer>().sprite = wallSprites[4];
                }
                else {
                    GetComponent<SpriteRenderer>().sprite = wallSprites[4];
                }
            }
            else {
                GetComponent<SpriteRenderer>().sprite = wallSprites[1];
            }
        }
        else if (up) {
            if (right) {
                if (down) {
                    GetComponent<SpriteRenderer>().sprite = wallSprites[Random.Range(0, 4)];
                }
                else {
                    GetComponent<SpriteRenderer>().sprite = wallSprites[0];
                }
            }
            else {
                if (down) {
                    GetComponent<SpriteRenderer>().sprite = wallSprites[Random.Range(2,4)];
                }
                else {
                    GetComponent<SpriteRenderer>().sprite = wallSprites[Random.Range(0, 4)];
                }
            }
        }
        else if (right) {
            if (down) {
                GetComponent<SpriteRenderer>().sprite = wallSprites[1];
            }
            else {
                GetComponent<SpriteRenderer>().sprite = wallSprites[Random.Range(0, 4)];
            }
        }
        else {
            GetComponent<SpriteRenderer>().sprite = wallSprites[Random.Range(0, 4)];
        }

        Destroy(this);
    }
    bool WallPositionCheck(Vector2 position) {
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.one, 0.1f);
        if (hit.collider != null && hit.collider.gameObject.tag == "Wall") {
            return (true);
        }
        else {
            return (false);
        }
    }
}
