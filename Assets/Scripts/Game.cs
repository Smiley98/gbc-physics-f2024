using UnityEngine;

public class Game : MonoBehaviour
{
    PhysicsSystem physicsSystem = new PhysicsSystem();

    void Start()
    {
        // Initialize bodies and them to physics system
        PhysicsBody body1 = new PhysicsBody();
        body1.pos = new Vector3(0.0f, 0.0f, 0.0f);
        body1.vel = new Vector3(0.0f, 10.0f, 0.0f);
        body1.drag = 0.05f; // *Must be between 0.0 and 1.0*
        physicsSystem.bodies.Add(body1);

        PhysicsBody body2 = new PhysicsBody();
        body2.pos = new Vector3(-2.0f, 0.0f, 0.0f);
        body2.vel = new Vector3(0.0f, 20.0f, 0.0f);
        body2.drag = 0.1f;
        physicsSystem.bodies.Add(body2);

        PhysicsBody body3 = new PhysicsBody();
        body3.pos = new Vector3(2.0f, 0.0f, 0.0f);
        body3.vel = new Vector3(0.0f, 30.0f, 0.0f);
        body3.drag = 0.2f;
        physicsSystem.bodies.Add(body3);
    }

    void FixedUpdate()
    {
        physicsSystem.Step(Time.fixedDeltaTime);
    }

    void OnDrawGizmos()
    {
        // TODO -- consider making this into a "Render()" method of PhysicsSystem
        for (int i = 0; i < physicsSystem.bodies.Count; i++)
        {
            PhysicsBody body = physicsSystem.bodies[i];
            Gizmos.DrawSphere(body.pos, 1.0f);
        }
    }
}
