using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

public partial struct SheepMovementSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<SheepMovement>();  
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var move = new float3(0, 0.1f, 0);
        foreach (var transform in SystemAPI.Query<RefRW<LocalTransform>>().WithAll<SheepAuthoring.Sheep>())
        {
            transform.ValueRW.Position += move;
            if (transform.ValueRW.Position.y > 100)
            {
                transform.ValueRW.Position = new float3(Random.Range(-50,50), 0, Random.Range(-50,50));
            }
        }
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
}
