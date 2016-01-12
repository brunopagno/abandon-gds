using UnityEngine;
using System.Collections;

public class TheBulletHell : MonoBehaviour {

    public Bullet bullet;
    public ParticleSystem showUp;
    public float fireRate = 2;
    public float range = 4;

    float timer = 0;

	void Update() {
        if (UtilControls.running) {
            timer += Time.deltaTime;

            if (timer > 1f / fireRate) {
                timer = 0;
                Bullet tiro = GameObject.Instantiate(bullet);
                tiro.transform.position = this.transform.position;
                // position bullet
                showUp.Play();
            }
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = new Color(0.3f, 0.8f, 1, 0.8f);
        Gizmos.DrawCube(transform.position, new Vector3(1, range));
    }

}
