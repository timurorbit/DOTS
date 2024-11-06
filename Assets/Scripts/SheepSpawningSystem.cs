using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using UnityEngine;
using UnityEngine.UIElements;
using Random = Unity.Mathematics.Random;

public partial struct SheepSpawningSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<SheepSpawning>();
        state.RequireForUpdate<Config>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        state.Enabled = false;

        var config = SystemAPI.GetSingleton<Config>();
        
        var random = new Random(123);

        var query = SystemAPI.QueryBuilder().WithAll<URPMaterialPropertyBaseColor>().Build();

        

        var queryMask = query.GetEntityQueryMask();

        var ecb = new EntityCommandBuffer(Allocator.Temp);
        var sheeps = new NativeArray<Entity>(config.sheepCount, Allocator.Temp);
        ecb.Instantiate(config.sheepPrefab, sheeps);

        foreach (var sheep in sheeps)
        {
           ecb.SetComponentForLinkedEntityGroup(sheep, queryMask,
               new URPMaterialPropertyBaseColor { Value = RandomColor(ref random)}
               );
        }
        
        ecb.Playback(state.EntityManager);
    }

    static float4 RandomColor(ref Random random)
    {
        // magic number is inverse of the golden ratio???
        var hue = (random.NextFloat() + 0.618034005f) % 1;
        return (Vector4) Color.HSVToRGB(hue, 1.0f, 1.0f);
    }
}
