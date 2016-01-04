using UnityEngine;
using System.Collections;

public abstract class Trigger : MonoBehaviour {

    public LayerMask triggerMask;
    public Vector2 size = new Vector2(1, 3);
    [HideInInspector]
    public bool active = false;

    void Update() {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, size, 0, Vector2.up, 0, triggerMask);
        if (hits.Length > 0) {
            if(!active) {
                active = true;
                this.activate();
            }
        } else {
            if(active) {
                active = false;
                this.deactivate();
            }
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = new Color(0, 0.5f, 0.5f, 0.5f);
        Gizmos.DrawCube(transform.position, size);
    }

    public abstract void activate();
    public abstract void deactivate();
}
