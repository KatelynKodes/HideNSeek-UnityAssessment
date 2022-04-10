using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    private Vector3 _velocity;

    public Vector3 Velocity { get { return _velocity; } set { _velocity = value; } }

    /// <summary>
    /// Gets the velocity using the start position 
    /// </summary>
    /// <param name="startPos"></param>
    /// <param name="endPos"></param>
    /// <param name="speed"></param>
    public void GetVelocity(Vector3 startPos, Vector3 endPos, float speed)
    {
        Vector3 direction = startPos - endPos;
        Velocity = direction.normalized * speed;
    }

    // Update is called once per frame
    virtual public void Update()
    {
        transform.position += Velocity * Time.deltaTime;
    }
}
