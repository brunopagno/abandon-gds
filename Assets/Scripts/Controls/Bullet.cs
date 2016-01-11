using UnityEngine;
using System.Collections;
using System;

public class Bullet : Trigger {

    public float speed = 1;
    private float lifeSpan = 5;
    private float timer = 0;

    public override void Activate() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Hit();
    }

    public override void OnUpdate() {
        transform.Translate(Vector2.left * speed * 0.1f);
        timer += Time.deltaTime;
        if (timer > lifeSpan) {
            GameObject.Destroy(this.gameObject);
        }
    }

    public override void Deactivate() { /* nothing */ }
    public override void Interact() { /* nothing */ }

}
