using UnityEngine;
using System.Collections;
using System;

public class HoleTrigger : Trigger {

    public string identifier;
    public GameObject[] targets;
    private bool triggered = false;

    public override void Activate() {
        if (triggered) return;

        StartCoroutine(UtilControls.MomentFreeze(0.5f));
        StartCoroutine(UtilControls.CameraShake(0.5f, 0.3f));
        this.Execute();
        GameObject.FindGameObjectWithTag("ThingsController").GetComponent<ThingsController>().DidTrigger(identifier);
    }

    public void Execute() {
        foreach (GameObject target in targets) {
            print("Target activeness => " + target.activeSelf);
            target.SetActive(!target.activeSelf);
            print("Target activeness => " + target.activeSelf);
        }
        triggered = true;
    }

    public override void Deactivate() { }

    public override void Interact() { }

}
