using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;
using System;

public partial struct EnemySpawnerSystem : ISystem
{
    public void OnCreate(ref SystemState state) { }
    public void OnDestroy(ref SystemState state) { }

    public void OnUpdate(ref SystemState state)
    {
        foreach ((RefRW<LocalTransform> transform, RefRW<EnemySpawner> spawner) in
            SystemAPI.Query<RefRW<LocalTransform>, RefRW<EnemySpawner>>())
        {
            spawner.ValueRW.Timer -= SystemAPI.Time.DeltaTime;
            if (spawner.ValueRW.Timer <= 0)
            {
                float randomPosition = UnityEngine.Random.Range(spawner.ValueRO.SpawningOffSetMin, spawner.ValueRO.SpawningOffSetMax);
                Entity enemy = state.EntityManager.Instantiate(spawner.ValueRO.EnemyPrefabs);
                state.EntityManager.SetComponentData(enemy, new LocalTransform
                {
                    Position = new float3(randomPosition, transform.ValueRO.Position.y, transform.ValueRO.Position.z),
                    Rotation = quaternion.identity,
                    Scale = UnityEngine.Random.Range(0.5f, 1)
                });

                spawner.ValueRW.Timer = spawner.ValueRW.SpawnTimer;
            }
        }
    }
}
