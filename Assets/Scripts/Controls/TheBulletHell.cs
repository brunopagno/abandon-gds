using UnityEngine;
using System.Collections;

public class TheBulletHell : MonoBehaviour {

    public Bullet bullet;
    public ParticleSystem showUp;
    public float fireRate = 2;
    public int volleyShots = 3;
    public float volleyTime = 1;
    public float range = 4;
    public float lifespan = 5;
    public Vector2 bulletDirection = Vector2.left;

    float timer = 0;
    float volleyTimer = 0;
    int shots;

    void Start() {
        volleyTimer = volleyTime;
    }

	void Update() {
        if (UtilControls.running) {
            volleyTimer += Time.deltaTime;

            if (volleyTimer > volleyTime) {
                timer += Time.deltaTime;

                if (timer > 1f / fireRate) {
                    timer = 0;
                    Bullet tiro = GameObject.Instantiate(bullet);
                    tiro.transform.position = this.transform.position;
                    tiro.lifeSpan = lifespan;
                    tiro.direction = bulletDirection;
                    shots += 1;
                    showUp.Play();
                    if (shots >= volleyShots) {
                        volleyTimer = 0;
                        shots = 0;
                    }
                }
            }
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = new Color(0.3f, 0.8f, 1, 0.8f);
        Gizmos.DrawCube(transform.position, new Vector3(1, range));
    }

}
