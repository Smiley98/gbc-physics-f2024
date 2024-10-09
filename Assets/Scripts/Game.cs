using UnityEngine;

public class Game : MonoBehaviour
{
    PhysicsSystem physicsSystem = new PhysicsSystem();

    void Start()
    {
        // Initialize bodies and them to physics system
        PhysicsBody ground = new PhysicsBody();
        ground.pos = Vector3.zero;
        ground.vel = Vector3.zero;
        ground.dynamic = false;
        ground.shapeType = ShapeType.PLANE;
        ground.normal = Vector3.up;
        physicsSystem.bodies.Add(ground);

        PhysicsBody body1 = new PhysicsBody();
        body1.pos = new Vector3(0.0f, 0.0f, 0.0f);
        body1.vel = new Vector3(0.0f, 10.0f, 0.0f);
        body1.drag = 0.05f; // *Must be between 0.0 and 1.0*
        body1.dynamic = true;
        body1.shapeType = ShapeType.SPHERE;
        body1.radius = 0.5f;
        physicsSystem.bodies.Add(body1);

        PhysicsBody body2 = new PhysicsBody();
        body2.pos = new Vector3(-2.0f, 0.0f, 0.0f);
        body2.vel = new Vector3(0.0f, 20.0f, 0.0f);
        body2.drag = 0.1f;
        body2.dynamic = true;
        body2.shapeType = ShapeType.SPHERE;
        body2.radius = 0.75f;
        physicsSystem.bodies.Add(body2);

        PhysicsBody body3 = new PhysicsBody();
        body3.pos = new Vector3(2.0f, 0.0f, 0.0f);
        body3.vel = new Vector3(0.0f, 30.0f, 0.0f);
        body3.drag = 0.2f;
        body3.dynamic = true;
        body3.shapeType = ShapeType.SPHERE;
        body2.radius = 1.0f;
        physicsSystem.bodies.Add(body3);
    }

    void FixedUpdate()
    {
        physicsSystem.Step(Time.fixedDeltaTime);
    }

    void OnDrawGizmos()
    {
        // (Planes are hard to validate without rotation, which requires a lot of effort to implement manually).
        // (Going to switch to GameObjects after reading week to allow for inspecter interaction).
        for (int i = 0; i < physicsSystem.bodies.Count; i++)
        {
            PhysicsBody body = physicsSystem.bodies[i];
            Gizmos.color = body.collision ? Color.red : Color.green;
            if (body.shapeType == ShapeType.SPHERE)
                Gizmos.DrawSphere(body.pos, body.radius);
            else if (body.shapeType == ShapeType.PLANE)
                Gizmos.DrawCube(body.pos, new Vector3(10.0f, 0.0f, 10.0f));
        }
    }
}
