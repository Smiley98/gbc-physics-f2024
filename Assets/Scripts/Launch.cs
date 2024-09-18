using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    public GameObject projectile;
    public float launchAngle;
    public float launchSpeed;

    Vector3 launchVelocity = Vector3.zero;

    // You can determine magnitude & direction using vector math on launch-velocity
    // These are just for reference because I want you to render the launch velocity
    Vector3 launchDirection = Vector3.up;
    float launchMagnitude = 10.0f;

    Vector3 acc = Physics.gravity;
    Vector3 vel = Vector3.zero;
    Vector3 pos = Vector3.zero;

    void Start()
    {
        // 1. Compute launch direction by decomposing launch-angle into horizontal & vertical components
        // 2. Compute launch velocity by multiplying launch-direction by launch-speed
    }

    void Update()
    {
        // 3. Complete the Relaunch function
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Relaunch();
            Debug.Log("Space Pressed!");
        }

        // 4. Apply motion based on position, velocity, and acceleration.

        // Replace this with actual launch velocity
        Debug.DrawLine(transform.position, transform.position + launchDirection * launchMagnitude, Color.magenta);
    }

    void Relaunch()
    {
        // 1. Reset position to initial position (ie zero)
        // 2. Reset velocity to initial velocity (launch velocity)
    }
}
