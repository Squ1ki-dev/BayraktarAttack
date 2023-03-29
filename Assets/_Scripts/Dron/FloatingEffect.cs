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
        minY =  transform.localPosition.y - floatingRange;
        maxY =  transform.localPosition.y + floatingRange;
        // Animate();
    }
    private void FixedUpdate()
    {
        if(transform.localPosition.y > maxY)  targetY = minY;
        else if(transform.localPosition.y < minY) targetY = maxY;
        transform.MoveToTarget(transform.localPosition.WithY(targetY), Time.fixedDeltaTime * speed);
    }
    // private void Animate()
    // {
    //     isFirstStep = !isFirstStep;
    //     transform.DOMoveY(startPosY + (isFirstStep ? floatingRange : -floatingRange), Mathf.Abs(startPosY - transform.position.y) / speed).OnComplete(() => Animate());
    // }
    // public void Stop() => transform.DOKill();

    // public void Resume() => Animate();
}