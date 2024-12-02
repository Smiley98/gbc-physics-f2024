using UnityEngine;

public class Game : MonoBehaviour
{
    // Position of launch is its centre
    public GameObject launch;

    public GameObject spherePrefab;
    public GameObject planePrefab;
    PhysicsSystem physicsSystem = new PhysicsSystem();

    void Start()
    {
        // Register collision callback
        physicsSystem.collisionCallback = CollisionTest;

        // Ground plane
        PhysicsBody ground = Instantiate(planePrefab).GetComponent<PhysicsBody>();
        //ground.transform.up = Vector3.Normalize(Vector3.right * 2.0f + Vector3.up);

        // Test sphere
        //PhysicsBody sphere1 = Instantiate(spherePrefab).GetComponent<PhysicsBody>();
        //sphere1.transform.position = Vector3.up * 0.5f;
        //sphere1.vel = Vector3.right * 5.0f;
        //sphere1.frictionCoefficient = 0.5f;
        //sphere1.restitutionCoefficient = 0.0f;
    }

    // Click to spawn test sphere
    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0.0f;

        // Vector FROM mouse TO launcher (AB = B - A):
        Vector3 slingshot = launch.transform.position - mouse;
        Debug.DrawLine(mouse, launch.transform.position, Color.cyan);

        // Spawn sphere and launch based on slingshot
        if (Input.GetMouseButtonDown(0))
        {
            PhysicsBody sphere = Instantiate(spherePrefab).GetComponent<PhysicsBody>();
            sphere.transform.position = launch.transform.position;
            sphere.vel = slingshot * 5.0f;
        }

        // Object removal test
        if (Input.GetMouseButtonDown(1))
        {
            physicsSystem.Clear();
        }
    }

    void FixedUpdate()
    {
        physicsSystem.PreStep();
        physicsSystem.Step(Time.fixedDeltaTime);
        physicsSystem.PostStep();
    }

    // Example of how to respond to collision (destroy pigs here)!
    void CollisionTest(GameObject a, GameObject b)
    {
        PhysicsBody ba = a.GetComponent<PhysicsBody>();
        PhysicsBody bb = b.GetComponent<PhysicsBody>();
        Debug.Log("Object " + a.name + " is colliding with " + b.name);
        Debug.Log("A's velocity: " + ba.vel);
        Debug.Log("B's velocity: " + bb.vel);
    }
}
