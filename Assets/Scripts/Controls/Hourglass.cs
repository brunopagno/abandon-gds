using UnityEngine;
using System.Collections;

public class Hourglass : Trigger {

    public Animator cutScene;

    public override void Activate() {
        UtilControls.Freeze();
        cutScene.Play("cutscene");

        GameObject.FindGameObjectWithTag("ThingsController").GetComponent<ThingsController>().ClearCurrentMemory();
    }

    public override void Deactivate() { /* nothing */ }
    public override void Interact() { /* nothing */ }

}
