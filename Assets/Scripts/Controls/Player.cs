using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(HeroPhysics))]
public class Player : MonoBehaviour {

    public float gravity = 25;
    public float jumpPower = 10;

    public int maxJumps = 1;
    public float jumpAttenuation = 2f;
    public float timeInvincible = 1.0f;

    public Inventory inventory;

    float accelerationTimeAirborne = 0.2f;
    float accelerationTimeGrounded = 0.1f;
    float moveSpeed = 6;
    int hits = 3;
    float invincibleTimer;
    bool invincible;
    bool lastCollisionBelow = true;

    int jumps;
    Vector3 velocity;
    float velocityXSmoothing;

    Animator heroAnimator;
    HeroPhysics heroPhysics;
    SpriteRenderer heroRenderer;
    Color defaultColor;

    void Start() {
        heroAnimator = GetComponentInChildren<Animator>();
        heroRenderer = GetComponentInChildren<SpriteRenderer>();
        heroPhysics = GetComponent<HeroPhysics>();
        defaultColor = heroRenderer.color;

        gravity *= -1;

        jumps = maxJumps;
        invincibleTimer = timeInvincible;

        inventory = new Inventory();
    }

    void SetFlip(float velocity) {
        Vector3 heroScale = transform.localScale;
        if (velocity > 0.5) {
            heroRenderer.flipX = false;
        } else if (velocity < -0.5) {
            heroRenderer.flipX = true;
        }
    }

    void Update() {
        if (Input.GetButtonDown("Action")) {
            StartCoroutine(UtilControls.CameraShake(0.1f, 0.5f));
        }

        if (UtilControls.running) {
            if (heroPhysics.collisions.above || heroPhysics.collisions.below) {
                velocity.y = 0;
            }

            if (heroPhysics.collisions.below) {
                jumps = maxJumps;
            } else if (lastCollisionBelow) {
                jumps--;
            }
            lastCollisionBelow = heroPhysics.collisions.below;

            Vector2 inputAxes = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (Input.GetButtonDown("Jump")) {
                if (inputAxes.y < -0.5) {
                    heroPhysics.DropPlatform();
                } else if (heroPhysics.collisions.below || jumps > 0) {
                    jumps--;
                    velocity.y = jumpPower;
                }
            }
            if (Input.GetButtonUp("Jump") && velocity.y > 0) {
                velocity.y -= velocity.y / jumpAttenuation;
            }

            float targetVelocityX = inputAxes.x * moveSpeed;
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (heroPhysics.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
            SetFlip(velocity.x);

            velocity.y += gravity * Time.deltaTime;
            heroPhysics.Move(velocity * Time.deltaTime, inputAxes);

            heroAnimator.SetFloat("horizontalSpeed", Mathf.Abs(heroPhysics.currentVelocity.x / Time.deltaTime));
            heroAnimator.SetFloat("verticalSpeed", heroPhysics.currentVelocity.y / Time.deltaTime);
            Debug.Log("vspeed: " + heroPhysics.currentVelocity.y / Time.deltaTime);
            heroAnimator.SetBool("onGround", heroPhysics.collisions.below);
            heroAnimator.SetBool("crouch", false);
            heroAnimator.SetBool("hit", invincible);
        }
        if (invincible) {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer <= 0) {
                invincible = false;
                invincibleTimer = timeInvincible;
            }
        }
    }

    public void Collect(Collectible collectible) {
        inventory.AddItem(collectible);
    }

    public void Hit() {
        if (!invincible) {
            invincible = true;
            hits -= 1;
            StartCoroutine(UtilControls.CameraShake(0.1f, 0.5f));
            if (hits > 0) {
                StartCoroutine(UtilControls.OneSecFreeze());
                StartCoroutine(FlashHero());
            } else {
                invincible = false;
                UtilControls.Freeze();
                //heroAnimator.SetBool("dead", true);
                StartCoroutine(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FadeScene>().FadeOutToScene("main"));
            }
        }
    }

    private IEnumerator FlashHero() {
        while (invincible) {
            heroRenderer.color = Color.red;
            yield return new WaitForSeconds(0.08f);
            heroRenderer.color = defaultColor;
            yield return new WaitForSeconds(0.08f);
        }
        yield return new WaitForSeconds(0);
    }
}
