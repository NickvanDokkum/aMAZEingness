using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnDungeonTiles : MonoBehaviour {

    List<Vector3> Coordinates;
    public int TileWidth;
    public int TileHeight;
    public int TileAmount;
    public GameObject Tile;
    public GameObject Player;
    public GameObject Exit;

    public void Awake() {
        TileAmount = PlayerPrefs.GetInt("TileAmount");
        if (TileAmount < 100) {
            TileAmount = 100;
            PlayerPrefs.SetInt("TileAmount", 100);
        }
        Coordinates = new List<Vector3>();
        Vector3 spawnPos = new Vector3(transform.position.x,transform.position.y,Player.transform.position.z);
        Instantiate(Player, spawnPos, transform.rotation);
        spawnPos.z = Tile.transform.position.z;
        GameObject temp = Instantiate(Tile, spawnPos, transform.rotation) as GameObject;
        temp.SendMessage("StopItems");
        Coordinates.Add(spawnPos);
        for (int i = 0; i < TileAmount;) {
            int R = Random.Range(0, 4);
            if (R == 0) {       //UP
                transform.Translate(Vector3.up * TileHeight);
            }
            else if (R == 1) {  //RIGHT
                transform.Translate(Vector3.right * TileWidth);
            }
            else if (R == 2) {  //DOWN
                transform.Translate(Vector3.down * TileHeight);
            }
            else {              //LEFT
                transform.Translate(Vector3.left * TileWidth);
            }
            spawnPos.x = transform.position.x; spawnPos.y = transform.position.y;
            if (PlaceFree(new Vector2(spawnPos.x, spawnPos.y))) {
                Instantiate(Tile, spawnPos, transform.rotation);
                Coordinates.Add(new Vector2(spawnPos.x, spawnPos.y));
                i++;
            }
        }
        spawnPos.z = Exit.transform.position.z;
        Instantiate(Exit, spawnPos, transform.rotation);
	}
    void Update() {
        Destroy(this.gameObject);
    }
    public bool PlaceFree(Vector2 position) {
        if(Coordinates.Contains(position)){
            return (false);
        }
        else {
            return (true);
        }
    }
    public void AddCoord(Vector2 coord) {
        Coordinates.Add(coord);
    }
}
