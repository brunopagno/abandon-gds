using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ThingsController : MonoBehaviour {

    private string currentMemory;
    public string CurrentMemory {
        get {
            return currentMemory;
        }
        set {
            currentMemory = value;
        }
    }
    private List<string> finishedMemories = new List<string>();
    private List<string> triggeredHoles = new List<string>();
    private List<string> collectedKeys = new List<string>();

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    void OnLevelWasLoaded() {
        // MEMORIES
        foreach (string identifier in finishedMemories) {
            GameObject trigger = FindMemoryTriggerByIdentifier(identifier);
            if (trigger != null) {
                trigger.SetActive(false);
            }
        }

        // HOLES
        foreach (string identifier in triggeredHoles) {
            GameObject trigger = FindHoleByIdentifier(identifier);
            if (trigger != null) {
                trigger.GetComponent<HoleTrigger>().Execute();
            }
        }

        // KEYS
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        foreach (string identifier in collectedKeys) {
            Collectible item = player.gameObject.AddComponent<Collectible>();
            item.identifier = identifier;
            player.Collect(item);
        }
        foreach (string identifier in collectedKeys) {
            GameObject key = FindKeyByIdentifier(identifier);
            if (key != null) {
                key.SetActive(false);
            }
        }
    }

    GameObject FindMemoryTriggerByIdentifier(string identifier) {
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

    GameObject FindKeyByIdentifier(string identifier) {
        GameObject[] keys = GameObject.FindGameObjectsWithTag("KeyItem");
        foreach (GameObject key in keys) {
            if (key.GetComponent<Collectible>().identifier == identifier) {
                return key;
            }
        }
        return null;
    }

    public void DidTrigger(string hole) {
        triggeredHoles.Add(hole);
    }

    public void ClearCurrentMemory() {
        finishedMemories.Add(CurrentMemory);
    }

    public void CollectedKey(string identifier) {
        collectedKeys.Add(identifier);
    }

}
