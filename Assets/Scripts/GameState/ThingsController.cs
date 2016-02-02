using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ThingsController : MonoBehaviour {

    private string currentTrigger;
    public string CurrentTrigger {
        get {
            return currentTrigger;
        }
        set {
            currentTrigger = value;
        }
    }
    private List<string> finishedTrigger = new List<string>();
    private List<string> triggeredHoles = new List<string>();

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    void OnLevelWasLoaded() {
        foreach (string identifier in finishedTrigger) {
            GameObject trigger = FindTriggerByIdentifier(identifier);
            if (trigger != null) {
                trigger.SetActive(false);
            }
        }

        foreach (string identifier in triggeredHoles) {
            GameObject trigger = FindHoleByIdentifier(identifier);
            if (trigger != null) {
                trigger.GetComponent<HoleTrigger>().Execute();
            }
        }
    }

    GameObject FindTriggerByIdentifier(string identifier) {
        GameObject[] triggers = GameObject.FindGameObjectsWithTag("MemoryTrigger");
        foreach (GameObject trigger in triggers) {
            if (trigger.GetComponent<MemoryTrigger>().identifier == identifier) {
                return trigger;
            }
        }
        return null;
    }

    GameObject FindHoleByIdentifier(string identifier) {
        GameObject[] triggers = GameObject.FindGameObjectsWithTag("HoleTrigger");
        foreach (GameObject trigger in triggers) {
            if (trigger.GetComponent<HoleTrigger>().identifier == identifier) {
                return trigger;
            }
        }
        return null;
    }

    public void DidTrigger(string hole) {
        triggeredHoles.Add(hole);
    }

    public void ClearCurrent() {
        finishedTrigger.Add(CurrentTrigger);
    }
}
