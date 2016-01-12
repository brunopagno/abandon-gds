using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CircleCollider2D))]
public class WheelPlatform : MonoBehaviour {

    public LayerMask passengerMask;

    public float speed = 10;
    public bool active = true;

    protected CircleCollider2D collider2d;

    List<PassengerMovement> passengerMovement;
    Dictionary<Transform, HeroPhysics> passengerDictionary = new Dictionary<Transform, HeroPhysics>();

    void Awake() {
        collider2d = GetComponent<CircleCollider2D>();
    }

    void Update () {
        if (UtilControls.running) {
            if (active) {
                float rotation = CalculatePlatformMovement(); // in degrees

                CalculatePassengerMovement(rotation);
                transform.Rotate(Vector3.back, rotation);
                MovePassengers();
            }
        }
    }

    float CalculatePlatformMovement() {
        return speed * Time.deltaTime;
    }
    
    void CalculatePassengerMovement(float rotation) {
        HashSet<Transform> movedPassengers = new HashSet<Transform> ();
        passengerMovement = new List<PassengerMovement> ();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(collider2d.bounds.center, collider2d.radius + RaycastController.skinWidth);

        foreach(var hit in colliders) {
            HeroPhysics heroPhysics = hit.GetComponent<HeroPhysics>();
            if (heroPhysics == null) continue;

            bool above = hit.transform.position.y > transform.position.y;
            if (!above) continue;

            if (!movedPassengers.Contains(hit.transform)) {
                movedPassengers.Add(hit.transform);

                float angle = Vector2.Angle(Vector2.right, transform.position - hit.transform.position);
                float originX = collider2d.radius * Mathf.Cos(Mathf.Deg2Rad * angle);
                float originY = collider2d.radius * Mathf.Sin(Mathf.Deg2Rad * angle);
                float targetX = collider2d.radius * Mathf.Cos(Mathf.Deg2Rad * (angle + rotation));
                float targetY = collider2d.radius * Mathf.Sin(Mathf.Deg2Rad * (angle + rotation));
                float deltaX = originX - targetX;
                float deltaY = originY - targetY;
                
                passengerMovement.Add(new PassengerMovement(hit.transform, new Vector3(deltaX, deltaY), true));
            }
        }
    }

    void MovePassengers() {
        foreach (PassengerMovement passenger in passengerMovement) {
            if (!passengerDictionary.ContainsKey(passenger.transform)) {
                passengerDictionary.Add(passenger.transform, passenger.transform.GetComponent<HeroPhysics>());
            }

            // THIS IS KINDA MUTRETA
            passengerDictionary[passenger.transform].transform.Translate(passenger.velocity);
        }
    }
    
    struct PassengerMovement {
        public Transform transform;
        public Vector3 velocity;
        public bool standingOnPlatform;
        
        public PassengerMovement(Transform _transform, Vector3 _velocity, bool _standingOnPlarform) {
            transform = _transform;
            velocity = _velocity;
            standingOnPlatform = _standingOnPlarform;
        }
    }
}
