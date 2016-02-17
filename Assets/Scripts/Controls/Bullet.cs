using UnityEngine;
using System.Collections;
using System;

public class Bullet : Trigger {

    public float speed = 1;
    public float lifeSpan = 5;
    private float timer = 0;
    public Vector2 direction = Vector2.left;

    public override void Activate() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Hit();
    }

    public override void OnUpdate() {
        transform.Translate(direction * speed * 0.1f);
        timer += Time.deltaTime;
        if (timer > lifeSpan) {
            GameObject.Destroy(this.gameObject);
        }
    }

    public override void Deactivate() { /* nothing */ }
    public override void Interact() { /* nothing */ }

}
