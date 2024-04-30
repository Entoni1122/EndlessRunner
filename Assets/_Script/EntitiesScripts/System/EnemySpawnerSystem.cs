using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Burst;
using UnityEngine;
using System;

public partial struct EnemySpawnerSystem : ISystem
{
    public void OnCreate(ref SystemState state) { }
    public void OnDestroy(ref SystemState state) { }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach ((RefRW<LocalTransform> transform, RefRW<EnemySpawner> spawner) in
            SystemAPI.Query<RefRW<LocalTransform>, RefRW<EnemySpawner>>())
        {
            spawner.ValueRW.Timer -= SystemAPI.Time.DeltaTime;
            if (spawner.ValueRW.Timer <= 0)
            {
                float randomPositionX = UnityEngine.Random.Range(spawner.ValueRO.SpawningOffSetMinX, spawner.ValueRO.SpawningOffSetMaxX);
                float randomPositionY = UnityEngine.Random.Range(spawner.ValueRO.SpawningOffSetMinY, spawner.ValueRO.SpawningOffSetMaxY);
                Entity enemy = state.EntityManager.Instantiate(spawner.ValueRO.EnemyPrefabs);
                state.EntityManager.SetComponentData(enemy, new LocalTransform
                {
                    Position = new float3(randomPositionX, randomPositionY + transform.ValueRO.Position.y, transform.ValueRO.Position.z),
                    Rotation = quaternion.identity,
                    Scale = UnityEngine.Random.Range(0.3f, 1)
                });

                spawner.ValueRW.Timer = spawner.ValueRW.SpawnTimer;
            }
        }
    }
}
