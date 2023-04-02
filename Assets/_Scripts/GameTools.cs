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

    public static bool HasGrount(Vector3 point, LayerMask layer)
    {
        // var l = Physics.Raycast(point.WithY(point.y + 100), Vector3.down, out RaycastHit testHit, Mathf.Infinity);
        // if(l) Debug.LogError(testHit.transform.gameObject.layer + " " + testHit.transform.IsInLayerMask(layer));
        return Physics.Raycast(point.WithY(point.y + 100), Vector3.down, out RaycastHit hit, Mathf.Infinity) &&  hit.transform.IsInLayerMask(layer);
    }

    public static void MoveToTarget(this Transform transform, Vector3 position, float step)
    {
        transform.position += transform.position.Direction(position) * step;
    }
    public static void LocalMoveToTarget(this Transform transform, Vector3 position, float step)
    {
        transform.localPosition += transform.localPosition.Direction(position) * step;
    }
}
