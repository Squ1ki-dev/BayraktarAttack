using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    [SerializeField] private float floatingRange = 2;
    [SerializeField] private float speed = 1;
    // float startPosY;
    float minY, maxY, targetY;
    bool isFirstStep;
    private void Start()
    {
        // startPosY = transform.position.y;
        minY =  transform.position.y - floatingRange;
        maxY =  transform.position.y + floatingRange;
        // Animate();
    }
    private void FixedUpdate()
    {
        if(transform.position.y > maxY)  targetY = minY;
        else if(transform.position.y < minY) targetY = maxY;
        transform.MoveToTarget(transform.position.WithY(targetY), Time.fixedDeltaTime * speed);
    }
    // private void Animate()
    // {
    //     isFirstStep = !isFirstStep;
    //     transform.DOMoveY(startPosY + (isFirstStep ? floatingRange : -floatingRange), Mathf.Abs(startPosY - transform.position.y) / speed).OnComplete(() => Animate());
    // }
    // public void Stop() => transform.DOKill();

    // public void Resume() => Animate();
}