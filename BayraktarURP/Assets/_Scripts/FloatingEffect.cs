using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    [SerializeField] private float floatingRange = 2;
    Vector3 startPos;
    private void Start()
    {
        startPos = transform.position;
        Animate();
    }
    private void Animate()
    {
        transform.DOMove(startPos.WithY(startPos.y + Random.Range(-floatingRange, floatingRange)), Vector3.Distance(startPos, transform.position)).OnComplete(() => Animate());
    }
}
