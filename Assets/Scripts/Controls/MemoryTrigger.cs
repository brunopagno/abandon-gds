using UnityEngine;
using System.Collections;
using System;

public class MemoryTrigger : Trigger {

    public override void Activate() {
        GameObject memoryIcon = GameObject.FindGameObjectWithTag("MemoryIcon");
        memoryIcon.GetComponent<SpriteRenderer>().enabled = true;
    }

    public override void Interact() {
        print("bagual!");
    }

    public override void Deactivate() {
        GameObject memoryIcon = GameObject.FindGameObjectWithTag("MemoryIcon");
        memoryIcon.GetComponent<SpriteRenderer>().enabled = false;
    }

}
