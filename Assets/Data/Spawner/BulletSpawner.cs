using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
   [SerializeField] protected static BulletSpawner instance;
   [SerializeField] public static BulletSpawner Instance{get => instance;}
   public static string bulletOne = "Bullet_1";
    protected override void Awake()
    {
        base.Awake();
         if(BulletSpawner.instance != null)Debug.Log("Only 1 BulletSpawner is exits");
        BulletSpawner.instance = this;
    }

}