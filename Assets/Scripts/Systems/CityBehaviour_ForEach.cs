using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Unity.Rendering;
using System.Collections.Generic;

public class CityBehaviour_ForEach : ComponentSystem
{ 
    
    protected override void OnUpdate()
    {
        EntityManager dstManager = World.EntityManager;
        
        Entities.ForEach((Entity entity, ref CityComponent cityComponent) =>
        {
            var deltaTime = Time.deltaTime;
            cityComponent.sicknessRate = math.frac(cityComponent.sicknessRate + deltaTime*0.05f);
        });
        
        Entities.ForEach((Entity entity, ref CityComponent cityComponent) =>
        {
            dstManager.GetSharedComponentData<RenderMesh>(entity).material.SetFloat("_Progress", cityComponent.sicknessRate);
        }); 
     }
}
