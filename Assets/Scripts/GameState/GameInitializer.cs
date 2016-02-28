using UnityEngine;
using System.Collections;

public class GameInitializer : MonoBehaviour {

    public GameObject thingsControllerPrefabPlease;
    public GameObject atticMemory;

    void Start() {
        if (GameObject.FindGameObjectWithTag("ThingsController") == null) {
            Instantiate(thingsControllerPrefabPlease);
        }
    }

    public void ActivateThisThingy() {
        atticMemory.SetActive(true);
    }

}
