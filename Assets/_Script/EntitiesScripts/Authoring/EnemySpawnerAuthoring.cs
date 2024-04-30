using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class EnemySpawnerAuthoring : MonoBehaviour
{
    public float SpawnTimer;
    public float Timer;
    public float SpawningOffSetMin;
    public float SpawningOffSetMax;

    public float SpawningOffSetMinY;
    public float SpawningOffSetMaxY;

    public GameObject EnemyPrefabs;

    public class Baker : Baker<EnemySpawnerAuthoring>
    {
        public override void Bake(EnemySpawnerAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new EnemySpawner()
            {
                SpawnTimer = authoring.SpawnTimer,
                Timer = authoring.Timer,
                SpawningOffSetMaxX = authoring.SpawningOffSetMax,
                SpawningOffSetMinX = authoring.SpawningOffSetMin,
                SpawningOffSetMaxY = authoring.SpawningOffSetMaxY,
                SpawningOffSetMinY = authoring.SpawningOffSetMinY,
                EnemyPrefabs = GetEntity(authoring.EnemyPrefabs,TransformUsageFlags.Dynamic)
            }); 
        }
    }
}

public struct EnemySpawner : IComponentData
{
    public float SpawnTimer;
    public Entity EnemyPrefabs;
    public float Timer;
    public float SpawningOffSetMinX;
    public float SpawningOffSetMaxX;
    public float SpawningOffSetMinY;
    public float SpawningOffSetMaxY;
}
