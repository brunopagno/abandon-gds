using UnityEngine;
using System.Collections;
using System;

public class HoleTrigger : Trigger {

    public GameObject target;
    private bool triggered = false;

    public override void Activate() {
        if (triggered) return;

        StartCoroutine(UtilControls.MomentFreeze(0.5f));
        StartCoroutine(UtilControls.CameraShake(0.5f, 0.3f));
        target.SetActive(!target.activeSelf);
        triggered = true;
    }

    public override void Deactivate() { }

    public override void Interact() { }

}
