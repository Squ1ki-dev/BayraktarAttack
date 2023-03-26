using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameTools
{
    public static float GetForce(this Joystick joystick) => joystick.Horizontal > joystick.Vertical ? joystick.Horizontal : joystick.Vertical;
    public static Vector3 Direction(this Vector3 from, Vector3 to) => (to - from).normalized;
    public static Vector3 WithZ(this Vector3 from, float z) => new Vector3(from.x, from.y, z);
    public static Vector3 WithX(this Vector3 from, float x) => new Vector3(x, from.y, from.z);
    public static Vector3 WithY(this Vector3 from, float y) => new Vector3(from.x, y, from.z);
    
    public static void MoveToTarget(this Transform transform, Vector3 position, float step)
    {
        transform.position += transform.position.Direction(position) * step;
    }
}
