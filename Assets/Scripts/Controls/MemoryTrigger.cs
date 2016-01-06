using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class MemoryTrigger : Trigger {

    public string sceneName;

    public override void Activate() {
        GameObject memoryIcon = GameObject.FindGameObjectWithTag("MemoryIcon");
        memoryIcon.GetComponent<SpriteRenderer>().enabled = true;
    }

    public override void Interact() {
        SceneManager.LoadScene("memoryan");
    }

    public override void Deactivate() {
        GameObject memoryIcon = GameObject.FindGameObjectWithTag("MemoryIcon");
        memoryIcon.GetComponent<SpriteRenderer>().enabled = false;
    }

}
