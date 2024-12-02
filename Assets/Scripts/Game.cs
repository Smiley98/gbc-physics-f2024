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
        // Ground plane
        PhysicsBody ground = Instantiate(planePrefab).GetComponent<PhysicsBody>();
        //ground.transform.up = Vector3.Normalize(Vector3.right * 2.0f + Vector3.up);

        // Test sphere
        PhysicsBody sphere1 = Instantiate(spherePrefab).GetComponent<PhysicsBody>();
        sphere1.transform.position = Vector3.up * 0.5f;
        sphere1.vel = Vector3.right * 5.0f;
        sphere1.frictionCoefficient = 0.5f;
        sphere1.restitutionCoefficient = 0.0f;

        // Bodies query moved to pre-step to handle dynamic add/remove
        physicsSystem.Init();
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
    }

    void FixedUpdate()
    {
        physicsSystem.PreStep();
        physicsSystem.Step(Time.fixedDeltaTime);
        physicsSystem.PostStep();
    }

    void OnDestroy()
    {
        physicsSystem.Quit();
    }
}
