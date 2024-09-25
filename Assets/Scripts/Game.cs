using UnityEngine;

public class Game : MonoBehaviour
{
    PhysicsSystem physicsSystem = new PhysicsSystem();

    void Start()
    {
        // TODO -- **Add MULTIPLE physics bodies to physicsSystem's bodies list**
        physicsSystem.testBody = new PhysicsBody();

        // Test body's initial settings
        physicsSystem.testBody.pos = new Vector3(0.0f, 1.0f, -1.0f);
        physicsSystem.testBody.vel = new Vector3(0.0f, 10.0f, 0.0f);
        physicsSystem.testBody.drag = 0.05f; // *Must be between 0.0 and 1.0*
    }

    void FixedUpdate()
    {
        // TODO -- Port your projectile (LE3) code to launch a projectile
        // using the physics system when space is pressed!
        float dt = Time.fixedDeltaTime;
        physicsSystem.time += dt;
        physicsSystem.Step(dt);
    }

    void OnDrawGizmos()
    {
        // (Once we switch to physicsSystem.bodies, the null error will go away
        // since it gets populated at runtime)
        Gizmos.DrawSphere(physicsSystem.testBody.pos, 1.0f);

        // TODO -- render all physics bodies
    }

    // This is over-engineered. Consider rolling your own "fixed-update for homework"
    //void Update()
    //{
    //    // The following loop ensures we only *ever* update (step) our physics system
    //    // at the desired frequency (100hz). 
    //    float dt = Time.deltaTime;
    //    physicsSystem.frameTime += dt;
    //    if (physicsSystem.frameTime >= physicsSystem.stepFrequency)
    //    {
    //        physicsSystem.Step(physicsSystem.stepFrequency);
    //        float extraTime = physicsSystem.frameTime - physicsSystem.stepFrequency;
    //        physicsSystem.frameTime = extraTime;
    //    }
    //}
}
