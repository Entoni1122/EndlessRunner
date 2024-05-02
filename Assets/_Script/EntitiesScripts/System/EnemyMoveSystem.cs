using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Burst;

public partial struct EnemyMoveSystem : ISystem
{
    public void OnCreate(ref SystemState state) { }
    public void OnDestroy(ref SystemState state) { }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach ((RefRW<LocalTransform> transform, RefRO<EnemyMove> moveStats) in
            SystemAPI.Query<RefRW<LocalTransform>, RefRO<EnemyMove>>())
        {
            float3 direction = -transform.ValueRO.Forward() * moveStats.ValueRO.Value * SystemAPI.Time.DeltaTime;
            //direction += transform.ValueRO.Position.y * MathF.Sin(Time.time) * SystemAPI.Time.DeltaTime;

            transform.ValueRW = transform.ValueRW.Translate(direction);
        }
    }
}
