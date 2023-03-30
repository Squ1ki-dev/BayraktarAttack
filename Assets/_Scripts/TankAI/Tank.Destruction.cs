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
        firePart.Play();
        IsDead = true;
        agent.updatePosition = false;
        this.Wait(boomParticle.main.duration, () =>
        {
            onLife.Invoke(this);
            firePart.Stop();
            agent.updatePosition = true;
            IsDead = false;
        });

    }
}
