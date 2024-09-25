using UnityEngine;

public class Game : MonoBehaviour
{
    PhysicsSystem physicsSystem = new PhysicsSystem();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        physicsSystem.Start();
    }

    // Update is called once per frame
    void Update()
    {
        physicsSystem.Update();
    }
}
