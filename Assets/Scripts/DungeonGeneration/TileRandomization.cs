using UnityEngine;
using System.Collections;

public class TileRandomization : MonoBehaviour {

    public GameObject wall;
    public GameObject chest;
    public GameObject bear;
    public GameObject firespitter;
    public GameObject bearTrap;
    public bool noItems = false;

    void Start() {
        //walls
        Vector3 spawnPos = transform.position;
        spawnPos.x -= 2;
        spawnPos.y += 2;
        Instantiate(wall, spawnPos, transform.rotation);
        spawnPos.y -= 2;
        Instantiate(wall, spawnPos, transform.rotation);
        spawnPos.y -= 2;
        Instantiate(wall, spawnPos, transform.rotation);
        spawnPos.y += 4;
        spawnPos.x += 2;
        Instantiate(wall, spawnPos, transform.rotation);
        spawnPos.y -= 4;
        Instantiate(wall, spawnPos, transform.rotation);
        spawnPos.y += 4;
        spawnPos.x += 2;
        Instantiate(wall, spawnPos, transform.rotation);
        spawnPos.y -= 2;
        Instantiate(wall, spawnPos, transform.rotation);
        spawnPos.y -= 2;
        Instantiate(wall, spawnPos, transform.rotation);
        if (!noItems) {
            //Placing Random Stuff
            int Item = Random.Range(0, 100);
            spawnPos = gameObject.transform.position;
            spawnPos.z -= 5;
            if (Item < 1) {
                Instantiate(chest, spawnPos, transform.rotation);
            }
            else if (Item < 21) {
                Instantiate(firespitter, spawnPos, transform.rotation);
            }
            else if (Item < 26) {
                Instantiate(bearTrap, spawnPos, transform.rotation);
            }
        }

        Destroy(this);
    }
}
