using UnityEngine;
using System.Collections;

public class Hourglass : Trigger {

    public string scene = "main";

    public override void Activate() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Freeze();
        StartCoroutine(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FadeScene>().FadeOutToScene(scene));
    }

    public override void Deactivate() { /* nothing */ }
    public override void Interact() { /* nothing */ }

}
