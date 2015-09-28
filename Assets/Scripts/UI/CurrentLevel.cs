using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentLevel : MonoBehaviour {

    public string noLvlText;
    public bool Current = false;

	void Start () {
        if (PlayerPrefs.GetInt("tileAmount") > 100) {
            if (!Current) {
                GetComponent<Text>().text = "level " + (((PlayerPrefs.GetInt("tileAmount") - 100) / 25) + 1);
            }
            else {
                GetComponent<Text>().text = "Current Level " + (((PlayerPrefs.GetInt("tileAmount") - 100) / 25) + 1);
            }
        }
        else {
            GetComponent<Text>().text = noLvlText;
        }
	}
}
