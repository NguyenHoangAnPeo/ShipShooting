using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandom : AnMonoBehaviour
{
    [Header("Spawner Random")]
    [SerializeField] protected SpawnCtrl spawnCtrl;
    [SerializeField] protected SpawnProfileSO spawnProfileSO;
    [SerializeField] protected float spawnDelay = 20f;
    [SerializeField] protected float timeSinceLastSpawn = 0f;
    [SerializeField] protected float spawnLimit = 2f;

    protected override void OnEnable()
    {
        base.OnEnable();

        if (Level.Instance != null)
            Level.Instance.OnLevelChanged += SetSpawnInfo;
        else
            Debug.LogWarning($"{transform.name}: Level.Instance chua khoi tao truoc OnEnable chay!");
    }

    protected virtual void OnDisable()
    {
        Level.Instance.OnLevelChanged -= SetSpawnInfo;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnCtrl();
        this.LoadSpawnProfileSO();
    }
    protected virtual void LoadSpawnCtrl()
    {
        if (this.spawnCtrl != null) return;
        this.spawnCtrl = GetComponent<SpawnCtrl>();
        Debug.Log(transform.name + ": LoadSpawnCtrl", gameObject);
    }
    protected virtual void LoadSpawnProfileSO()
    {
        if (this.spawnProfileSO != null) return;
        string resPath = "SpawnProfile/"+transform.name;
        this.spawnProfileSO = Resources.Load<SpawnProfileSO>(resPath);
    }
    
    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }
    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;
        this.timeSinceLastSpawn += Time.fixedDeltaTime;
        if (this.timeSinceLastSpawn < this.spawnDelay) return;
        this.timeSinceLastSpawn = 0f;

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
        return currentJunk >= this.spawnLimit;
    }
    protected virtual void SetSpawnInfo(int newLevel)
    {
        this.spawnDelay = Mathf.Max(1f, spawnProfileSO.baseInterval - newLevel * 0.2f);
        this.spawnLimit = spawnProfileSO.baseLimit + Mathf.FloorToInt(newLevel / 3f);
    }
}