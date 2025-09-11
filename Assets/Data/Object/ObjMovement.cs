using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : AnMonoBehaviour
{
   [SerializeField] protected Vector3 targetPosition;
   [SerializeField] protected float speed = 0.02f;
   [SerializeField] protected float distance = 1f;
   [SerializeField] protected float minDistance = 1f;
   protected virtual void FixedUpdate()
   {
      this.MoveShip();
   }
   protected virtual void MoveShip()
   {
      this.distance = Vector3.Distance(transform.position, this.targetPosition);
      if (this.distance < minDistance) return;

      Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, this.speed);
      transform.parent.position = newPos;
   }
   public virtual void SetSpeed(float speed)
   {
      this.speed = speed;
   }
}
