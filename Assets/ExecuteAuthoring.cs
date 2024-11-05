using Unity.Entities;
using UnityEngine;

public class ExecuteAuthoring : MonoBehaviour
{
    public bool SheepMovement;


    public bool SheepColoring;


    public bool SheepSpawning;

    class Baker : Baker<ExecuteAuthoring>
    {
        public override void Bake(ExecuteAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);

            if (authoring.SheepMovement)
                AddComponent<SheepMovement>(entity);
            if (authoring.SheepColoring)
                AddComponent<SheepColoring>(entity);
            if (authoring.SheepSpawning)
                AddComponent<SheepSpawning>(entity);
        }
    }
}

public struct SheepMovement : IComponentData
{
}

public struct SheepColoring : IComponentData
{
}

public struct SheepSpawning : IComponentData
{
}