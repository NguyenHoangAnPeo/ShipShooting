using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityWarp : BaseAbility
{
    [Header("Warp")]
    [SerializeField] protected Spawner spawner;
    [SerializeField] protected bool isWarping = false;
    protected Vector4 keyDirection;
    [SerializeField] protected Vector4 warpDiretion;
    [SerializeField] protected float warpSpeed = 0.5f;
    [SerializeField] protected float warpDistance = 2f;
    protected override void Update()
    {
        base.Update();
        this.CheckWarpDirection();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Warping();
    }
    protected virtual void CheckWarpDirection()
    {
        if (!this.isReady) return;
        if (this.isWarping) return;

        if (this.keyDirection.x == 1) this.WarpLeft();
        if (this.keyDirection.y == 1) this.WarpRight();
        if (this.keyDirection.z == 1) this.WarpUp();
        if (this.keyDirection.w == 1) this.WarpDown();
    }
    protected virtual void WarpLeft()
    {
        Debug.Log("WarpLeft");
        this.warpDiretion.x = 1;
    }
    protected virtual void WarpRight()
    {
        Debug.Log("WarpRight");
        this.warpDiretion.y = 1;
    }
    protected virtual void WarpUp()
    {
        Debug.Log("WarpUp");
        this.warpDiretion.z = 1;
    }
    protected virtual void WarpDown()
    {
        Debug.Log("WarpDown");
        this.warpDiretion.w = 1;
    }
    protected virtual void Warping()
    {
        if (this.isWarping) return;
        if (this.IsDirectionNotSet()) return;

        Debug.LogWarning("Warping");
        Debug.LogWarning(this.warpDiretion);

        this.isWarping = true;
        Invoke(nameof(this.WarpFinish), this.warpSpeed);
    }
    protected virtual bool IsDirectionNotSet()
    {
        return this.warpDiretion.x == 0 && this.warpDiretion.y == 0 
            && this.warpDiretion.z == 0 && this.warpDiretion.w == 0;
    }
    protected virtual void WarpFinish()
    {
        this.MoveObj();
        this.warpDiretion.Set(0, 0, 0, 0);
        this.isWarping = false;
        this.Active();
    }
    protected virtual void MoveObj()
    {
        Transform obj = this.abilities.AbilityObjectCtrl.transform;
        Vector3 newPos = obj.position;
        if(this.warpDiretion.x == 1) newPos.x -= this.warpDistance;
        if(this.warpDiretion.y == 1) newPos.x += this.warpDistance;
        if(this.warpDiretion.z == 1) newPos.y += this.warpDistance;
        if(this.warpDiretion.w == 1) newPos.y -= this.warpDistance;

        Quaternion fxRot = this.GetFXQuaternion();
        Transform fx = FXSpawner.Instance.Spawn(FXSpawner.impact_1, obj.position, fxRot);
        fx.gameObject.SetActive(true);

        obj.position = newPos;
    }
    protected virtual Quaternion GetFXQuaternion()
    {
        Vector3 vector = new Vector3();
        if (this.warpDiretion.x == 1) vector.z = 0;
        if (this.warpDiretion.y == 1) vector.z = 180;
        if (this.warpDiretion.z == 1) vector.z = -90;
        if (this.warpDiretion.w == 1) vector.z = 90;

        if (this.warpDiretion.x == 1 && this.warpDiretion.w == 1) vector.z = 45;
        if (this.warpDiretion.x == 1 && this.warpDiretion.z == 1) vector.z = -45;
        if (this.warpDiretion.y == 1 && this.warpDiretion.w == 1) vector.z = 135;
        if (this.warpDiretion.y == 1 && this.warpDiretion.z == 1) vector.z = -135;

        return Quaternion.Euler(vector);
    }
}
