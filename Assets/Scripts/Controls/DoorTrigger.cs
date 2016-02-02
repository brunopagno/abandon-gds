using UnityEngine;
using System.Collections;

public class DoorTrigger : Trigger {

    public string identifier;
    public GameObject[] targets;
    private bool triggered = false;

    public override void Activate() {
        if (triggered) return;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().HasItem(identifier);

        this.Execute();
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
