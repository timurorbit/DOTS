using Unity.Entities;
using UnityEngine;

public class ConfigAuthoring : MonoBehaviour
{
    public GameObject sheepPrefab;
    public int SheepCount;

    class Baker : Baker<ConfigAuthoring>
    {
        public override void Bake(ConfigAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new Config
            {
                sheepPrefab = GetEntity(authoring.sheepPrefab, TransformUsageFlags.Dynamic),
                sheepCount = authoring.SheepCount
            });
        }
    }
}

public struct Config : IComponentData
{
    public Entity sheepPrefab;
    public int sheepCount;
}