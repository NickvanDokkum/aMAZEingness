using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnDungeonTiles : MonoBehaviour {

    List<Vector2> coordinates;
    public int tileWidth;
    public int tileHeight;
    public int tileAmount;
    public GameObject tile;
    public GameObject saveTile;
    public GameObject player;
    public GameObject exit;

    public void Awake() {
        tileAmount = PlayerPrefs.GetInt("tileAmount");
        if (tileAmount < 100) {
            tileAmount = 100;
            PlayerPrefs.SetInt("tileAmount", 100);
        }
        coordinates = new List<Vector2>();
        Vector3 spawnPos = new Vector3(transform.position.x,transform.position.y,player.transform.position.z);
        Instantiate(player, spawnPos, transform.rotation);
        spawnPos.z = tile.transform.position.z;
        Instantiate(saveTile, spawnPos, transform.rotation);
        coordinates.Add(new Vector2(spawnPos.x, spawnPos.y));
        for (int i = 0; i < tileAmount;) {
            int R = Random.Range(0, 4);
            if (R == 0) {       //UP
                transform.Translate(Vector3.up * tileHeight);
            }
            else if (R == 1) {  //RIGHT
                transform.Translate(Vector3.right * tileWidth);
            }
            else if (R == 2) {  //DOWN
                transform.Translate(Vector3.down * tileHeight);
            }
            else {              //LEFT
                transform.Translate(Vector3.left * tileWidth);
            }
            spawnPos.x = transform.position.x; spawnPos.y = transform.position.y;
            if (PlaceFree(new Vector2(spawnPos.x, spawnPos.y))) {
                if (i != tileAmount -1) {
                    Instantiate(tile, spawnPos, transform.rotation);
                }
                else {
                    Instantiate(saveTile, spawnPos, transform.rotation);
                }
                coordinates.Add(new Vector2(spawnPos.x, spawnPos.y));
                i++;
            }
        }
        spawnPos.z = exit.transform.position.z;
        Instantiate(exit, spawnPos, transform.rotation);
	}
    void Update() {
        Destroy(this.gameObject);
    }
    public bool PlaceFree(Vector2 position) {
        if(coordinates.Contains(position)){
            return (false);
        }
        else {
            return (true);
        }
    }
    public void AddCoord(Vector2 coord) {
        coordinates.Add(coord);
    }
}
