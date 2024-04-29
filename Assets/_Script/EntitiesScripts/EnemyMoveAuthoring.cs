using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class EnemyMoveAuthoring : MonoBehaviour
{
    public float Value;

    public class Baker : Baker<EnemyMoveAuthoring>
    {
        public override void Bake(EnemyMoveAuthoring authoring)
        {
            var entir = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entir, new EnemyMove()
            {
                Value = authoring.Value
            });
        }
    }
}

public struct EnemyMove : IComponentData
{
    public float Value;
}