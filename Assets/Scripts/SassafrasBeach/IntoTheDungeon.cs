using UnityEngine;
using System.Collections;

public class IntoTheDungeon : MonoBehaviour {

	void OnTriggerEnter2D(){
        GameObject.Find("TransitionScreen").GetComponent<Darkness>().Change(true, 2);
    }
}
