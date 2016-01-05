using UnityEngine;
using System.Collections;
using System;

public class Bullet : Trigger {

    public float speed = 1;
    private float lifeSpan = 5;

    public override void Activate() {
        print("ACONTECEU!");
    }

    public override void Deactivate() { /* nothing */ }

    public override void Interact() { /* nothing */ }

    public override void OnUpdate() {
        transform.Translate(Vector2.left * speed * 0.1f);
    }

}
