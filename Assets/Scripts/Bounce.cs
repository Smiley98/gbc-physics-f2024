using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    // Consider using 3d vectors instead of 1d scalars to describe velocity & acceleration
    public float acc = Physics.gravity.y;
    public float vel = 0.0f;
    public float pos = 5.0f;
    // Acceleration is "change in velocity"
    // Velocity is "change in position"

    void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;
        vel = vel + acc * dt; // Update velocity based on acceleration
        pos = pos + vel * dt; // Update position based on velocity

        // Apply motion to Unity GameObject via Transform component
        transform.position = new Vector3(0.0f, pos, 0.0f);

        // Homework:
        // if ball is below the ground:
        //      -negate ball velocity, causing it to bounce!
    }
}
