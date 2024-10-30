using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject spherePrefab;
    public GameObject planePrefab;
    PhysicsSystem physicsSystem = new PhysicsSystem();

    void Start()
    {
        PhysicsBody ground = Instantiate(planePrefab).GetComponent<PhysicsBody>();
        ground.transform.up = Vector3.right;
        ground.transform.position = Vector3.left * 2.0f;

        PhysicsBody sphere = Instantiate(spherePrefab).GetComponent<PhysicsBody>();
        sphere.transform.position = Vector3.up * 7.0f;
        sphere.drag = 0.001f;
    }

    void FixedUpdate()
    {
        physicsSystem.PreStep();
        physicsSystem.Step(Time.fixedDeltaTime);
        physicsSystem.PostStep();
    }
}
