using UnityEngine;
using System.Collections;
using System;

public class Collectible : Trigger {

    public string identifier;

    public override void Activate() {
        if (source) {
            source.PlayOneShot(clip, 0.5f);
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Collect(this);
        GameObject.FindGameObjectWithTag("ThingsController").GetComponent<ThingsController>().CollectedKey(identifier);
        GameObject.Destroy(this.gameObject);
    }

    public override void Deactivate() {}

    public override void Interact() {}
}
