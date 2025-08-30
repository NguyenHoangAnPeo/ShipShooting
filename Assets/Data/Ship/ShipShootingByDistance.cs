using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootingByDistance : ShipShooting
{
    [Header("ShipShoot By Distance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = Mathf.Infinity;
    [SerializeField] protected float shootDistance = 5f;
    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected override bool IsShooting()
    {
        this.distance = Vector3.Distance(transform.position, this.target.position);
        this.isShooting = this.distance < this.shootDistance;
        return this.isShooting;
    }
}