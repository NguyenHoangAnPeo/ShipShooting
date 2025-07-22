using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected Transform bulletPrefab;
    [SerializeField] protected float shootDelay = 2f;
    [SerializeField] protected float shootTimer = 0f;
     void Update(){
        this.IsShooting();
        this.Shooting();
    }
    protected virtual void Shooting()
    {
        if (!this.isShooting) return;  //Neu dang khong ban, tra ve khong gi ca, khong thi debug shoot;
        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0f;
        Vector3 spawnPos = transform.position; // lay vi tri hien tai
        Quaternion rotation = transform.parent.rotation; //lay goc quay cua doi tuong cha
        // Transform newBullet = Instantiate(this.bulletPrefab,spawnPos,rotation);
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation); // spawn vien dan;
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
        Debug.Log("Shoot");
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent);
    }
     protected bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFire == 1;
        return this.isShooting;
    }
}