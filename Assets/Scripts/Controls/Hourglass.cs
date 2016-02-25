using UnityEngine;
using System.Collections;

public class Hourglass : Trigger {

    public GameObject cutsceneObject;
    private Animator cutScene;

    public override void Activate() {
        cutsceneObject.SetActive(true);
        cutScene = cutsceneObject.GetComponent<Animator>();
        if (source) {
            source.PlayOneShot(clip, 0.5f);
        }
        UtilControls.Freeze();
        cutScene.Play("cutscene");

        GameObject.FindGameObjectWithTag("ThingsController").GetComponent<ThingsController>().ClearCurrentMemory();
    }

    public override void Deactivate() { /* nothing */ }
    public override void Interact() { /* nothing */ }

}
