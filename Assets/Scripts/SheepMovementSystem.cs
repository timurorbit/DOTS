using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

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
        var move = new float3(0, 0, 0.1f);
        foreach (var transform in SystemAPI.Query<RefRW<LocalTransform>>().WithAll<SheepAuthoring.Sheep>())
        {
            transform.ValueRW.Position += move;
            if (transform.ValueRW.Position.z > 50)
            {
                transform.ValueRW.Position.z = 0;
            }
        }
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
}
