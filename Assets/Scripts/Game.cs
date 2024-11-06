using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject spherePrefab;
    public GameObject planePrefab;
    PhysicsSystem physicsSystem = new PhysicsSystem();

    // Sphere 2 should push sphere 3 to the right, all spheres should roll (infinitely) along the plane!
    void Start()
    {
        PhysicsBody ground = Instantiate(planePrefab).GetComponent<PhysicsBody>();

        //PhysicsBody sphere1 = Instantiate(spherePrefab).GetComponent<PhysicsBody>();
        //sphere1.transform.position = Vector3.up * 5.0f;
        //sphere1.drag = 0.001f;

        PhysicsBody sphere2 = Instantiate(spherePrefab).GetComponent<PhysicsBody>();
        sphere2.transform.position = Vector3.right * 2.0f + Vector3.up * 0.5f;
        sphere2.invMass = 0.0f; // static sphere (can't move)

        PhysicsBody sphere3 = Instantiate(spherePrefab).GetComponent<PhysicsBody>();
        sphere3.transform.position = Vector3.up * 0.5f;
        sphere3.vel = Vector3.right * 5.0f;
        // spheres are dynamic by default!
    }

    void FixedUpdate()
    {
        physicsSystem.PreStep();
        physicsSystem.Step(Time.fixedDeltaTime);
        physicsSystem.PostStep();
    }
}
