using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhysicsSystem
{
    // Default gravity of -9.81m/s^2 downwards (along the y-axis)
    public Vector3 gravity = new Vector3(0.0f, -9.81f, 0.0f);

    // We don't actually need total time, just doing it to match the lab document xD
    public float time = 0.0f;

    // TODO -- add multiply bodies within Game's start function
    public List<PhysicsBody> bodies = new List<PhysicsBody>();

    public PhysicsBody testBody;

    public void Step(float dt)
    {
        // so we'll store it as a uniform acceleration for all objects
        Vector3 acc = gravity;

        // Apply drag to velocity
        testBody.vel *= Mathf.Pow(testBody.drag, dt);
        
        // Apply motion
        Integrate(ref testBody.vel, acc, dt);
        Integrate(ref testBody.pos, testBody.vel, dt);
    }

    // "Integration" is updating a value based on the previous value + its change
    private void Integrate(ref Vector3 value, Vector3 change, float dt)
    {
        value = value + change * dt;
    }
}
