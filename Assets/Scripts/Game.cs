using UnityEngine;

public class Game : MonoBehaviour
{
    PhysicsSystem physicsSystem = new PhysicsSystem();

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        physicsSystem.Step(Time.fixedDeltaTime);
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
