using UnityEngine;

public class Game : MonoBehaviour
{
    PhysicsSystem physicsSystem = new PhysicsSystem();

    void Start()
    {
        // **Add MULTIPLE physics bodies to physicsSystem's bodies list**
        physicsSystem.testBody = new PhysicsBody();

        // Test body's initial settings
        physicsSystem.testBody.pos = new Vector3(0.0f, 1.0f, 0.0f);
    }

    void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;
        physicsSystem.time += dt;
        physicsSystem.Step(dt);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(physicsSystem.testBody.pos, 1.0f);
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
