using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct ConnectionComponent : IComponentData
{
    public City pointA;
    public City pointB;

    public Vector3 posA;
    public Vector3 posB;
}
