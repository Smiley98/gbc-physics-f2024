using UnityEngine;

public class PhysicsSystem
{
    // Default gravity of -9.81m/s^2 downwards (along the y-axis)
    public Vector3 gravity = new Vector3(0.0f, -9.81f, 0.0f);

    // We don't actually need total time, just doing it to match the lab document xD
    public float time = 0.0f;

    public void Step(float dt)
    {
        Debug.Log("Desired update frequency: " + Time.fixedDeltaTime);
        Debug.Log("Actual update frequency: " + dt);
        Debug.Log("Total time: " + time);
    }
}
