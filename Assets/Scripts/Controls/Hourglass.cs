using UnityEngine;
using System.Collections;

public class Hourglass : Trigger {

    public string scene = "main";
    public Animator cutScene;

    public override void Activate() {
        // this should probably set somewhere that the memory was "completed"
        UtilControls.Freeze();

        cutScene.Play("cutscene");
        while (cutScene.GetAnimatorTransitionInfo(0).IsName("cutscene")) {
            print("playing cutscene");
        }

        print("done with cutscene");

        StartCoroutine(Camera.main.GetComponent<FadeScene>().FadeOutToScene(scene));
    }

    public override void Deactivate() { /* nothing */ }
    public override void Interact() { /* nothing */ }

}
