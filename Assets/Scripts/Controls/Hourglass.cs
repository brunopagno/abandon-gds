using UnityEngine;
using System.Collections;

public class Hourglass : Trigger {

    public GameObject cutsceneObject;
    public Animator cutScene;

    void Start() {
        //cutScene = cutsceneObject.GetComponent<Animator>();
    }

    public override void Activate() {
        UtilControls.Freeze();
        cutScene.Play("cutscene");

        GameObject.FindGameObjectWithTag("ThingsController").GetComponent<ThingsController>().ClearCurrentMemory();
    }

    public override void Deactivate() { /* nothing */ }
    public override void Interact() { /* nothing */ }

}
