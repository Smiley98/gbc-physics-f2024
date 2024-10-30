using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhysicsSystem
{
    public Vector3 gravity = Physics.gravity;

    // Apply changes from GameObject to PhysicsBody
    public void PreStep()
    {
        PhysicsBody[] bodies = GameObject.FindObjectsByType<PhysicsBody>(FindObjectsSortMode.None);
        for (int i = 0; i < bodies.Length; i++)
        {
            if (bodies[i].shapeType == ShapeType.PLANE)
            {
                bodies[i].normal = bodies[i].transform.up;
            }

            bodies[i].pos = bodies[i].transform.position;
            bodies[i].gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    // Apply changes from PhysicsBody to GameObject
    public void PostStep()
    {
        PhysicsBody[] bodies = GameObject.FindObjectsByType<PhysicsBody>(FindObjectsSortMode.None);
        for (int i = 0; i < bodies.Length; i++)
        {
            Color color = bodies[i].collision ? Color.red : Color.green;
            bodies[i].gameObject.GetComponent<Renderer>().material.color = color;
            bodies[i].transform.position = bodies[i].pos;
        }
    }

    public void Step(float dt)
    {
        PhysicsBody[] bodies = GameObject.FindObjectsByType<PhysicsBody>(FindObjectsSortMode.None);
        for (int i = 0; i < bodies.Length; i++)
        {
            // Current physics object ("body")
            PhysicsBody body = bodies[i];

            Vector3 acc = body.dynamic ? gravity : Vector3.zero;

            // Apply drag to velocity
            body.vel *= Mathf.Pow(body.drag, dt);

            // Apply motion
            Integrate(ref body.vel, acc, dt);
            Integrate(ref body.pos, body.vel, dt);

            // Apply position calculated in our physics update back to Unity
            body.transform.position = body.pos;
        }
        
        // Reset collision flag before hit-testing
        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].collision = false;
        }

        // Write a 2d for-loop that tests all objects against all objects
        for (int i = 0; i < bodies.Length; i++)
        {
            for (int j = i + 1; j < bodies.Length; j++)
            {
                // Check collision here
                PhysicsBody a = bodies[i];
                PhysicsBody b = bodies[j];

                // Future TODO for Connor: make A always dynamic and B static or dynamic, do so by making a Manifold object
                // For now, assuming all spheres are dynamic, and all planes are static for simplicity.
                Vector3 mtv = Vector3.zero;
                bool collision = false;
                if (a.shapeType == ShapeType.SPHERE && b.shapeType == ShapeType.SPHERE)
                {
                    // Translate each sphere 50% along MTV
                    collision = SphereSphere(a.pos, a.radius, b.pos, b.radius, out mtv);
                    a.pos += mtv * 0.5f;
                    b.pos -= mtv * 0.5f;
                }
                else if (a.shapeType == ShapeType.SPHERE && b.shapeType == ShapeType.PLANE)
                {
                    // Resolve sphere from plane
                    collision = SpherePlane(a.pos, a.radius, b.pos, b.normal, out mtv);
                    a.pos += mtv;
                }
                else if (a.shapeType == ShapeType.PLANE && b.shapeType == ShapeType.SPHERE)
                {
                    // Resolve sphere from plane
                    collision = SpherePlane(b.pos, b.radius, a.pos, a.normal, out mtv);
                    b.pos += mtv;
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
        // Collision if distance between centres is less than radii sum
        float distance = Vector3.Distance(position1, position2);
        float radiiSum = radius1 + radius2;
        return distance <= radiiSum;
    }

    private bool SpherePlane(Vector3 spherePosition, float radius, Vector3 planePosition, Vector3 normal)
    {
        // Collision if distance of circle projected onto plane normal is less than radius
        float distance = Vector3.Dot(spherePosition - planePosition, normal);
        return distance <= radius;
    }

    // Ensure MTV resolves A from B (1 from 2)
    private bool SphereSphere(Vector3 position1, float radius1, Vector3 position2, float radius2, out Vector3 mtv)
    {
        bool collision = SphereSphere(position1, radius1, position2, radius2);
        if (collision)
        {
            // Calculate mtv
            mtv = Vector3.zero; // (replace this)
        }
        else
        {
            mtv = Vector3.zero;
        }
        return collision;
    }

    // Ensure MTV points FROM plane TO sphere
    private bool SpherePlane(Vector3 spherePosition, float radius, Vector3 planePosition, Vector3 normal, out Vector3 mtv)
    {
        bool collision = SpherePlane(spherePosition, radius, planePosition, normal);
        if (collision)
        {
            mtv = Vector3.zero; // (replace this)
        }
        else
        {
            mtv = Vector3.zero;
        }
        return collision;
    }
}
