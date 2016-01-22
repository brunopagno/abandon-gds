using UnityEngine;
using System.Collections;

public class Hourglass : Trigger {

    public Animator cutScene;

    public override void Activate() {
        // this should probably set somewhere that the memory was "completed"
        UtilControls.Freeze();

        cutScene.Play("cutscene");
    }

    public override void Deactivate() { /* nothing */ }
    public override void Interact() { /* nothing */ }

}
