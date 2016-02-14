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
        ThingsController tc = GameObject.FindGameObjectWithTag("ThingsController").GetComponent<ThingsController>();        
        tc.CurrentMemory = identifier;
        tc.UpdateThePositioning(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().transform.position);
        StartCoroutine(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FadeScene>().FadeOutToScene(sceneName));
    }

    public override void Deactivate() {
        GameObject memoryIcon = GameObject.FindGameObjectWithTag("MemoryIcon");
        memoryIcon.GetComponent<SpriteRenderer>().enabled = false;
    }

}
