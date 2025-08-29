using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : AnMonoBehaviour
{
   [SerializeField] protected Vector3 targetPosition;
   [SerializeField] protected float speed = 0.02f;
   [SerializeField] protected float distance = 1f;
   [SerializeField] protected float minDistance = 4f;
   protected virtual void FixedUpdate()
   {
      this.LookAtTarget();
      this.MoveShip();
   }

   protected void LookAtTarget(){
        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x)*Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f,0f,rot_z);
   }
   protected virtual void MoveShip() {
      this.distance = Vector3.Distance(transform.position, this.targetPosition);
      if (this.distance < minDistance) return;

      Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition , this.speed);
      transform.parent.position = newPos;
   }
}
