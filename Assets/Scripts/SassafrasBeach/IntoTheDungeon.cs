using UnityEngine;
using System.Collections;

public class IntoTheDungeon : MonoBehaviour {

	void OnTriggerEnter2D(){
        Application.LoadLevel(2);
    }
}
