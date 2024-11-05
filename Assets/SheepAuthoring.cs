using Unity.Entities;
using UnityEngine;

public class SheepAuthoring : MonoBehaviour
{
    class Baker : Baker<SheepAuthoring>
    {
        public override void Bake(SheepAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent<Sheep>(entity);
        }
    }

    public struct Sheep : IComponentData
    {
        
    }
}
