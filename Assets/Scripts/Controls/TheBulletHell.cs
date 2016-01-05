using UnityEngine;
using System.Collections;

public class TheBulletHell : MonoBehaviour {

    public Bullet bullet;
    public float fireRate = 3;
    public float range = 4;

    float timer = 0;

	void Update () {
        timer += Time.deltaTime;

        if (timer > 1f / fireRate) {
            timer = 0;
            Bullet tiro = GameObject.Instantiate(bullet);
        }
	}

    void OnDrawGizmos() {
        Gizmos.color = new Color(0.3f, 0.8f, 1, 0.8f);
        Gizmos.DrawCube(transform.position, new Vector3(1, range));
    }

}
