using UnityEngine;
using System.Collections;
using System;

public class DeathBlock : Trigger {

    public override void Activate() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Kill();
    }

    public override void Deactivate() {}

    public override void Interact() {}

}
