using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    [SerializeField] private float floatingRange = 2;
    float startPosY;
    bool isFirstStep;
    bool isStoped;
    private void Start()
    {
        startPosY = transform.position.y;
        Animate();
    }
    private void Animate()
    {
        if (isStoped) return;
        isFirstStep = !isFirstStep;
        transform.DOMoveY(startPosY + (isFirstStep ? floatingRange : -floatingRange), Mathf.Abs(startPosY - transform.position.y)).OnComplete(() => Animate());
    }
    public void Stop()
    {
        isStoped = true;
        transform.DOKill();
    }
    public void Resume()
    {
        if (!isStoped)
        {
            isStoped = false;
            Animate();
        }
    }
}
