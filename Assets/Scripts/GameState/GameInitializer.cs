using UnityEngine;
using System.Collections;

public class GameInitializer : MonoBehaviour {

    public GameObject thingsControllerPrefabPlease;

    void Start() {
        if (GameObject.FindGameObjectWithTag("ThingsController") == null) {
            Instantiate(thingsControllerPrefabPlease);
        }
    }

}
