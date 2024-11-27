using UnityEngine;

public class Game : MonoBehaviour
{
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

        // Static sphere ("immovable object")
        //PhysicsBody sphere2 = Instantiate(spherePrefab).GetComponent<PhysicsBody>();
        //sphere2.transform.position = Vector3.right * 2.0f + Vector3.up * 0.5f;
        //sphere2.invMass = 0.0f;
        //
        //// Dynamic sphere ("unstoppable force")
        //PhysicsBody sphere3 = Instantiate(spherePrefab).GetComponent<PhysicsBody>();
        //sphere3.transform.position = Vector3.up * 0.5f;
        //sphere3.vel = Vector3.right * 2.0f;

        physicsSystem.Init();
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
