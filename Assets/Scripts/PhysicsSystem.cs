using UnityEngine;

public class PhysicsSystem
{
    // Default gravity of -9.81m/s^2 downwards (along the y-axis)
    public Vector3 gravity = new Vector3(0.0f, -9.81f, 0.0f);

    public void Step(float dt)
    {
        Debug.Log("Desired update frequency: " + stepFrequency);
        Debug.Log("Actual update frequency: " + frameTime);
    }
}
