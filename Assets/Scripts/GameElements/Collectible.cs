using UnityEngine;
using System.Collections;
using System;

public class Collectible : Trigger {

    public override void Activate() {
        print("Collectible;");
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Collect(this);
    }

    public override void Deactivate() {}

    public override void Interact() {}
}
