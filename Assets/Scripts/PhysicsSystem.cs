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

    // Example of the behaviour I want *multiple* of:
    public PhysicsBody testBody;

    public void Step(float dt)
    {
        // Time information:
        //Debug.Log("Desired update frequency: " + Time.fixedDeltaTime);
        //Debug.Log("Actual update frequency: " + dt);
        //Debug.Log("Total time: " + time);

        // TODO -- apply motion (acceleration, velocity, position) to list of bodies instead of just testBody

        // Right now, our only acceleration is due to gravity,
        // so we'll store it as a uniform acceleration for all objects
        Vector3 acc = gravity;

        // Apply drag to velocity
        testBody.vel *= Mathf.Pow(testBody.drag, dt);

        // "New velocity is equal to old velocity + change in velocity" (a * t)
        testBody.vel = testBody.vel + acc * dt;

        // "New position is equal to old position + change in position" (v * t)
        testBody.pos = testBody.pos + testBody.vel * dt;
    }
}
