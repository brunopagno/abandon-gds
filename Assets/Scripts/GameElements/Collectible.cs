using UnityEngine;
using System.Collections;
using System;

public class Collectible : Trigger {

    public string identifier;

    public override void Activate() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Collect(this);
        GameObject.Destroy(this.gameObject);
    }

    public override void Deactivate() {}

    public override void Interact() {}
}
