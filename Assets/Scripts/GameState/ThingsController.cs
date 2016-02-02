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
    private List<string> finished = new List<string>();

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    void OnLevelWasLoaded() {
        foreach (string identifier in finished) {
            GameObject trigger = FindTriggerByIdentifier(identifier);
            if (trigger != null) {
                trigger.SetActive(false);
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

    public void ClearCurrent() {
        finished.Add(CurrentTrigger);
    }
}
