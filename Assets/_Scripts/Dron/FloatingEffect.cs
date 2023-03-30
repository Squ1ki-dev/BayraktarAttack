using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    [SerializeField] private float floatingRange = 2;
    [SerializeField] private float speed = 1;
    float minY, maxY, targetY;
    bool isFirstStep;
    private void Start()
    {
        minY = transform.localPosition.y - floatingRange;
        maxY = transform.localPosition.y + floatingRange;
        targetY = maxY;
    }
    private void FixedUpdate()
    {
        if (transform.localPosition.y >= maxY) targetY = minY;
        else if (transform.localPosition.y <= minY) targetY = maxY;
        transform.LocalMoveToTarget(transform.localPosition.WithY(targetY), Time.fixedDeltaTime * speed);
    }
}