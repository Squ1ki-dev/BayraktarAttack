using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.Events;

public partial class Tank
{
    public UnityEvent<Tank> onLife = new();
    public bool IsDead { get; private set; }
    public void Kill()
    {
        boomParticle.Play();
        firePart.SetActive(true);
        firePart.Play();
        IsDead = true;
        agent.updatePosition = false;
        agent.updateRotation = false;
        this.Wait(boomParticle.main.duration, () =>
        {
            onLife.Invoke(this);
            firePart.Stop();
            firePart.SetActive(false);
            agent.updatePosition = true;
            agent.updateRotation = true;
            IsDead = false;
        });

    }
}
