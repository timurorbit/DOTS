using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using UnityEngine;

public partial class SheepAspect : IAspect
{ 
    RefRW<SheepAuthoring.Sheep> sheep;

    private RefRW<URPMaterialPropertyBaseColor> m_BaseColor;

    public float4 Color => m_BaseColor.ValueRW.Value;
}
