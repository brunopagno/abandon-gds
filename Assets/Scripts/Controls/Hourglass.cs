using UnityEngine;
using System.Collections;

public class Hourglass : Trigger {

    public string scene = "main";

    public override void Activate() {
        UtilControls.Freeze();
        StartCoroutine(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FadeScene>().FadeOutToScene(scene));
    }

    public override void Deactivate() { /* nothing */ }
    public override void Interact() { /* nothing */ }

}
