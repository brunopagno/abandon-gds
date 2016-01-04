using UnityEngine;
using System.Collections;

[RequireComponent (typeof (HeroPhysics))]
public class Player : MonoBehaviour {

	public float gravity = 25;
	public float jumpPower = 10;
	public int maxJumps = 1;
	public float jumpAttenuation = 2f;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;
	float moveSpeed = 6;
    bool lastCollisionBelow = true;
	
	int jumps;
	Vector3 velocity;
	float velocityXSmoothing;

	Animator heroAnimator;
	HeroPhysics heroPhysics;
    SpriteRenderer heroRenderer;

    void Start() {
		heroAnimator = GetComponentInChildren<Animator>();
        heroRenderer = GetComponentInChildren<SpriteRenderer>();
        heroPhysics = GetComponent<HeroPhysics>();
        
        gravity *= -1;

		jumps = maxJumps;
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
		if (heroPhysics.collisions.above || heroPhysics.collisions.below) {
			velocity.y = 0;
		}

		if(heroPhysics.collisions.below) {
            jumps = maxJumps;
        } else if(lastCollisionBelow) {
            jumps--;
        }
        lastCollisionBelow = heroPhysics.collisions.below;

		Vector2 inputAxes = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

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
		velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (heroPhysics.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
        SetFlip(velocity.x);

		velocity.y += gravity * Time.deltaTime;
        heroPhysics.Move(velocity * Time.deltaTime, inputAxes);
		//heroAnimator.SetFloat ("horizontalSpeed", Mathf.Abs(heroPhysics.currentVelocity.x / Time.deltaTime));
		//heroAnimator.SetFloat ("verticalSpeed", heroPhysics.currentVelocity.y / Time.deltaTime);
		//heroAnimator.SetBool ("onGround", heroPhysics.collisions.below);
	}
}
