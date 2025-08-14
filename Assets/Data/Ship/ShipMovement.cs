using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
   [SerializeField] protected Vector3 worldPosition;
   [SerializeField] protected float speed = 0.02f;
   void FixedUpdate(){
    this.GetPos();
    this.LookAtTarget();
    this.MoveShip();
   }
   protected virtual void GetPos(){
      this.worldPosition = InputManager.Instance.WorldMousePos;
    this.worldPosition.z=0;
   }
   protected void LookAtTarget(){
        Vector3 diff = this.worldPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x)*Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f,0f,rot_z);
   }
   protected virtual void MoveShip() {
       Vector3 newPos = Vector3.Lerp(transform.parent.position, worldPosition , this.speed);
    transform.parent.position = newPos;
   }
}
