using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    public float launchAngle;
    public float launchSpeed;

    // Launch velocity = launch direction * launch magnitude
    Vector3 launchVelocity = Vector3.zero;

    Vector3 launchDirection = Vector3.up;
    float launchMagnitude = 10.0f;

    Vector3 acc = Vector3.zero;
    Vector3 vel = Vector3.zero;
    Vector3 pos = Vector3.zero;

    bool launched = false;

    // Poll input in update to prevent missed inputs, apply single-use changes on-input.
    void Update()
    {
        // Reset
        if (Input.GetKeyDown(KeyCode.R))
            ResetProjectile();

        // Launch
        if (Input.GetKeyDown(KeyCode.L))
            LaunchProjectile();
    }

    // ***DO NOT PUT INPUT P0LLING IN HERE AS IT ONLY RUNS AT 50HZ BY DEFAULT***
    void FixedUpdate()
    {
        // Update motion
        float dt = Time.fixedDeltaTime;
        vel = vel + acc * dt;
        pos = pos + vel * dt;

        // Render motion
        transform.position = pos;
        Debug.DrawLine(transform.position, transform.position + launchDirection * launchMagnitude, Color.magenta);
    }

    void ResetProjectile()
    {
        Debug.Log("Reseting Projectile...");
        acc = Vector3.zero;
        vel = Vector3.zero;
        pos = Vector3.zero;
        launched = false;
    }

    void LaunchProjectile()
    {
        Debug.Log("Launching Projectile!!!");
        launchVelocity = launchDirection * launchMagnitude;
        acc = Physics.gravity;
        vel = launchVelocity;
        launched = true;
    }
}
