﻿using UnityEngine;
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
        if (source) {
            source.PlayOneShot(clip, 0.5f);
        }
        this.Execute();
        GameObject.FindGameObjectWithTag("ThingsController").GetComponent<ThingsController>().DidTrigger(identifier);
    }

    public void Execute() {
        foreach (GameObject target in targets) {
            target.SetActive(!target.activeSelf);
        }
        triggered = true;
    }

    public override void Deactivate() { }

    public override void Interact() { }

}
