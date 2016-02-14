using UnityEngine;
using System.Collections;
using System;

public class SpringPlatform : Trigger {

    public override void Activate() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().ForceJump(14);
    }

    public override void Deactivate() {}

    public override void Interact() {}

}
