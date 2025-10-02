using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : AnMonoBehaviour
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }
    protected virtual void FixedUpdate(){
        this.Despawning();
    }
        protected virtual void Despawning(){
        if(!this.CanDespawn())return;
        this.DespawnObject();
        //Debug.Log("Destroy game Bullet");
    }
    public virtual void DespawnObject(){
        Destroy(transform.parent.gameObject);
    }
    protected abstract bool CanDespawn();
}