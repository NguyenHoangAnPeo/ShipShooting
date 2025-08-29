using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCtrl : AnMonoBehaviour
{
    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner;
    [SerializeField] protected SpawnPoints spawnPoint;
    public SpawnPoints SpawnPoints {get => spawnPoint;}

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadSpawnPoints();
    }
    
    protected virtual void LoadSpawner(){
        if(this.spawner != null) return;
        this.spawner = GetComponent<Spawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }
    protected virtual void LoadSpawnPoints(){
        if(this.spawnPoint != null) return;
        this.spawnPoint = Transform.FindObjectOfType<JunkSpawnPoints>();
        Debug.Log(transform.name + ": LoadSpawnPoints",gameObject);
    }
}
