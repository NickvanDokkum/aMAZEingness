using UnityEngine;
using System.Collections;

public class EnableDeathScreen : MonoBehaviour {

    public GameObject theGameObject;

    public void EnableTheGameobject() {
        theGameObject.SetActive(true);
    }
}
