using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class ConnectionJobSystem : ComponentSystem
{


    protected override void OnUpdate()
    {
        Entities.ForEach((ref ConnectionComponent connection) =>
        {
        });
    }
}
