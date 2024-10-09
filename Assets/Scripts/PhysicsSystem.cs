using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhysicsSystem
{
    public Vector3 gravity = Physics.gravity;
    public List<PhysicsBody> bodies = new List<PhysicsBody>();

    public void Step(float dt)
    {
        for (int i = 0; i < bodies.Count; i++)
        {
            // Current physics object ("body")
            PhysicsBody body = bodies[i];

            Vector3 acc = body.dynamic ? gravity : Vector3.zero;

            // Apply drag to velocity
            body.vel *= Mathf.Pow(body.drag, dt);

            // Apply motion
            Integrate(ref body.vel, acc, dt);
            Integrate(ref body.pos, body.vel, dt);
        }
        
        // Reset collision flag before hit-testing
        for (int i = 0; i < bodies.Count; i++)
        {
            bodies[i].collision = false;
        }

        // Write a 2d for-loop that tests all objects against all objects
        for (int i = 0; i < bodies.Count; i++)
        {
            for (int j = i + 1; j < bodies.Count; j++)
            {
                // Check collision here
                PhysicsBody a = bodies[i];
                PhysicsBody b = bodies[j];

                bool collision = false;
                if (a.shapeType == ShapeType.SPHERE && b.shapeType == ShapeType.SPHERE)
                {
                    collision = SphereSphere(a.pos, a.radius, b.pos, b.radius);
                }
                else if (a.shapeType == ShapeType.SPHERE && b.shapeType == ShapeType.PLANE)
                {
                    collision = SpherePlane(a.pos, a.radius, b.pos, b.normal);
                }
                else if (a.shapeType == ShapeType.PLANE && b.shapeType == ShapeType.SPHERE)
                {
                    collision = SpherePlane(b.pos, b.radius, a.pos, a.normal);
                }
                else
                {
                    Debug.LogError("Invalid collision test");
                }

                // Update collision flag
                a.collision |= collision;
                b.collision |= collision;
            }
        }
    }

    // "Integration" is updating a value based on the previous value + its change
    private void Integrate(ref Vector3 value, Vector3 change, float dt)
    {
        value = value + change * dt;
    }

    private bool SphereSphere(Vector3 position1, float radius1, Vector3 position2, float radius2)
    {
        return position1.y >= 0.0f;
    }

    // LE6 TODO 2: Complete this function to determine if a sphere and plane are overlapping
    private bool SpherePlane(Vector3 spherePosition, float radius, Vector3 planePosition, Vector3 normal)
    {
        // 1. Compute the circle's position relative to the plane by subtracting the plane's position FROM the circle's position.
        // 2. Project the circle's relative position along the plane's normal by taking the dot-product of the relative position and the normal ie Vector3.Dot(a, b)
        // 3. Check if the dot-product (magnitude of the projection) is less than the radius of the sphere (collision if so)!
        return false;
    }
}
