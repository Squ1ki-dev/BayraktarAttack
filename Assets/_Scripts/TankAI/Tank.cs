using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public partial class Tank : MonoBehaviour
{
    public NavMeshAgent agent;
    public float range; //radius of sphere
    public bool isStoped = false;
    public Transform centrePoint;

    [SerializeField] private ParticleSystem boomParticle, firePart;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(isStoped) return;
        MoveTank();
    }

    public void Stop() => isStoped = true;
}
