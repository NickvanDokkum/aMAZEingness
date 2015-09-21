using UnityEngine;
using System.Collections;

public class TileRandomization : MonoBehaviour {

    public GameObject Wall;
    public GameObject Chest;
    public GameObject Enemy;
    public GameObject FireSpitter;
    public bool NoItems = false;

    void Start() {
        //Walls
        Vector3 spawnPos = transform.position;
        spawnPos.x -= 2;
        spawnPos.y += 2;
        Instantiate(Wall, spawnPos, transform.rotation);
        spawnPos.y -= 2;
        Instantiate(Wall, spawnPos, transform.rotation);
        spawnPos.y -= 2;
        Instantiate(Wall, spawnPos, transform.rotation);
        spawnPos.y += 4;
        spawnPos.x += 2;
        Instantiate(Wall, spawnPos, transform.rotation);
        spawnPos.y -= 4;
        Instantiate(Wall, spawnPos, transform.rotation);
        spawnPos.y += 4;
        spawnPos.x += 2;
        Instantiate(Wall, spawnPos, transform.rotation);
        spawnPos.y -= 2;
        Instantiate(Wall, spawnPos, transform.rotation);
        spawnPos.y -= 2;
        Instantiate(Wall, spawnPos, transform.rotation);
        if (!NoItems) {
            //Placing Random Stuff
            int Item = Random.Range(0, 100);
            spawnPos = gameObject.transform.position;
            spawnPos.z -= 5;
            if (Item < 1) {
                Instantiate(Chest, spawnPos, transform.rotation);
            }
            else if (Item < 6) {
                Instantiate(Enemy, spawnPos, transform.rotation);
            }
            else if (Item < 21) {
                Instantiate(FireSpitter, spawnPos, transform.rotation);
            }
        }

        Destroy(this);
    }
}
