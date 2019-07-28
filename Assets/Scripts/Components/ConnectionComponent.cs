using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct ConnectionComponent : IComponentData
{
    public City connection;

    public ConnectionComponent(City connection)
    {
        this.connection = connection;
    }
}
