using UnityEngine;
using System.Collections;
using System;

public class MemoryTrigger : Trigger {

    public override void activate() {
        GameObject memoryIcon = GameObject.FindGameObjectWithTag("MemoryIcon");
        memoryIcon.GetComponent<SpriteRenderer>().enabled = true;
    }

    public override void deactivate() {
        GameObject memoryIcon = GameObject.FindGameObjectWithTag("MemoryIcon");
        memoryIcon.GetComponent<SpriteRenderer>().enabled = false;
    }

}
