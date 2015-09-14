using UnityEngine;
using System.Collections;

public class WallSelector : MonoBehaviour {

    public Sprite[] wallSprites;
    SpawnDungeonTiles script;

    void Awake() {
        script = GameObject.Find("DungeonGenerator").GetComponent<SpawnDungeonTiles>();
        if (!script.PlaceFree(new Vector2(transform.position.x, transform.position.y))) {
            Destroy(this.gameObject);
        }
        else {
            script.AddCoord(new Vector2(transform.position.x, transform.position.y));
        }
    }
    void Update() {
        Destroy(this);
    }
}
