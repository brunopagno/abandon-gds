using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class MemoryTrigger : Trigger {

    public string identifier;
    public string sceneName;

    public override void Activate() {
        GameObject memoryIcon = GameObject.FindGameObjectWithTag("MemoryIcon");
        memoryIcon.GetComponent<SpriteRenderer>().enabled = true;
    }

    public override void Interact() {
        StartCoroutine(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FadeScene>().FadeOutToScene(sceneName));
        GameObject.FindGameObjectWithTag("ThingsController").GetComponent<ThingsController>().CurrentMemory = identifier;
    }

    public override void Deactivate() {
        GameObject memoryIcon = GameObject.FindGameObjectWithTag("MemoryIcon");
        memoryIcon.GetComponent<SpriteRenderer>().enabled = false;
    }

}
