using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbility : AnMonoBehaviour
{
    [Header("Base Ability")]
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float delay = 2f;
    [SerializeField] protected bool isReady = false;

    protected virtual void FixedUpdate()
    {
        this.Timing();
    }
    protected virtual void Timing()
    {
        if (this.isReady) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.isReady = true;
    }
    protected virtual void Active()
    {
        this.timer = 0;
        this.isReady = false;
    }
}
