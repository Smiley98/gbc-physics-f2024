using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunkyMotion : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public float amplitude;
    public float frequency;
    public float dt;
    public float time;

    void FixedUpdate()
    {
        // We don't want Time.deltaTime because it *varies*.
        // We want a fixed time-step to ensure our physics engine is stable!
        //Debug.Log(dt);
        
        dt = Time.fixedDeltaTime;

        z = Mathf.Sin(time);

        // Move our object based on custom motion!
        transform.position = new Vector3(x, y, z);

        time += dt;
    }

    // Variable timestamp, MUCH faster than the default fixed-time-stamp of 50hz
    //void Update()
    //{
    //    float dt = Time.deltaTime;
    //    Debug.Log(dt);
    //}
}
