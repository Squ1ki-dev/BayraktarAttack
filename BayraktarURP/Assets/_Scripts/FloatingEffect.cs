using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    [SerializeField] private float floatingRange = 2;
    float startPosY;
    bool isFirstStep;

    private void Start()
    {
        startPosY = transform.position.y;
        Animate();
    }
    private void Animate()
    {
        isFirstStep = !isFirstStep;
        transform.DOMoveY(startPosY + (isFirstStep ? floatingRange : -floatingRange), Mathf.Abs(startPosY - transform.position.y)).OnComplete(() => Animate());
    }

    public void Stop()
    {
        transform.DOKill();
    }
    
    public void Resume()
    {
        Animate();
    }
}
