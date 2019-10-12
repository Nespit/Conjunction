using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class CityBehaviour_ForEach : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref CityComponent cityComponent) =>
        {
            var deltaTime = Time.deltaTime;
            
        });
    }
}
