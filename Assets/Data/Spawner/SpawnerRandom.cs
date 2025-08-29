using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandom : AnMonoBehaviour
{
    [Header("Spawner Random")]
    [SerializeField] protected SpawnCtrl spawnCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 9f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnCtrl();
    }
    protected virtual void LoadSpawnCtrl()
    {
        if (this.spawnCtrl != null) return;
        this.spawnCtrl = GetComponent<SpawnCtrl>();
        Debug.Log(transform.name + ": LoadSpawnCtrl", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }
    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;
        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0f;

        Transform ranPoint = this.spawnCtrl.SpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = this.spawnCtrl.Spawner.RandomPrefab();
        Transform obj = this.spawnCtrl.Spawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
        //Invoke(nameof(this.JunkSpawning), 1f);
    }
    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.spawnCtrl.Spawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }
}