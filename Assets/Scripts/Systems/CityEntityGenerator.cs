using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Rendering;

[RequiresEntityConversion]
public class CityEntityGenerator : MonoBehaviour, IConvertGameObjectToEntity
{
    //private EntityManager entityManager;
    [SerializeField]
    public GameObject cityGameObject;
    public Material circleMaterial;

    [SerializeField]
    public City city;

    //[SerializeField]
    //List<City> connections;

    [SerializeField]
    public int healthyPopulation;

    [SerializeField]
    public int sickPopulation;

    [SerializeField]
    public float moral;

    [SerializeField]
    public int industry;

    [SerializeField]
    public float sicknessRate;

    [SerializeField]
    public int sicknessDetectionLevel;

    [SerializeField]
    public int infrastructureLevel;

    [SerializeField]
    public int quarantineLevel;

    //private void Start()
    //{
    //    entityManager = World.Active.EntityManager;

    //    var data = new CityComponent(city, healthyPopulation, sickPopulation, moral, industry, sicknessRate, sicknessDetectionLevel, infrastructureLevel, quarantineLevel);
    //    var entity = entityManager.CreateEntity();
    //    entityManager.AddComponentData(entity, data);

    //    for (int i = 0; i < connections.Count; ++i)
    //    {
    //        var dataX = new ConnectionComponent(connections[i]);
    //        entityManager.AddComponentData(entity, dataX);
    //    }
    //}


    private Mesh PolygonalMesh(float radius, uint sides)
    {
        Vector3[] vertices = new Vector3[sides];
        Vector2[] uv = new Vector2[sides];
        uint trianglesCount = sides-2;
        int[] triangleIndices = new int[(trianglesCount)*3];

        float x;
        float y;

        //Vertices
        for (int i = 0; i < sides; ++i)
        {
            x = radius * Mathf.Sin((2 * Mathf.PI * i) / sides);
            y = radius * Mathf.Cos((2 * Mathf.PI * i) / sides);
            vertices[i] = new Vector3(x, y, 0f);
        }

        //UVs
        for (int i = 0; i < sides; ++i)
        {
            uv[i] = -Vector3.forward;
        }

        //Triangles
        for (int i = 0; i < trianglesCount; ++i)
        {
            triangleIndices[3*i] = 0;
            triangleIndices[3*i + 1] = i + 1;
            triangleIndices[3*i + 2] = i + 2;
        }

        Mesh mesh = new Mesh
        {
            vertices = vertices,
            uv = uv,
            triangles = triangleIndices
        };

        return mesh;
    }

    private Mesh DoubleSidedPolygonalMesh(float radius, float width, uint sides)
    {
        Vector3[] vertices = new Vector3[sides*2+2];
        Vector2[] uv = new Vector2[sides*2+2];
        uint triangleCount = sides*2;
        int[] triangleIndices = new int[triangleCount * 3];

        //Vertices & UVs
        float x;
        float y;

        for (int i = 0; i <= sides; ++i)
        {
            x = radius * Mathf.Sin((2 * Mathf.PI * i) / sides);
            y = radius * Mathf.Cos((2 * Mathf.PI * i) / sides);
            vertices[i*2] = new Vector3(x, y, 0f);

            x = (radius - width) * Mathf.Sin((2 * Mathf.PI * i) / sides);
            y = (radius - width) * Mathf.Cos((2 * Mathf.PI * i) / sides);
            vertices[i*2+1] = new Vector3(x, y, 0f);

            uv[i*2] = new Vector2((float)i/(float)sides,1f);
            uv[i*2+1] = new Vector2((float)i/(float)sides,0f);
        }

        //vertices[sides*2] = vertices[0];
        //vertices[sides*2+1] = vertices[1];

        //Triangles
        for (int i = 0; i < triangleCount; ++i)
        {
            if (i % 2 != 0)
            {
                triangleIndices[i * 3] = i;
                triangleIndices[i * 3 + 1] = (i + 1);
                triangleIndices[i * 3 + 2] = (i + 2);
            }
            else
            {
                triangleIndices[i * 3 + 1] = i ;
                triangleIndices[i * 3] = (i + 1);
                triangleIndices[i * 3 + 2] = (i + 2);
            }  
        }

        Mesh mesh = new Mesh
        {
            vertices = vertices,
            uv = uv,
            triangles = triangleIndices
        };

        return mesh;
    }


    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var data = new CityComponent(cityGameObject.transform.position, city, healthyPopulation, sickPopulation, moral, industry, sicknessRate, sicknessDetectionLevel, infrastructureLevel, quarantineLevel);
        dstManager.AddComponentData(entity, data);
    
        dstManager.AddSharedComponentData(entity, new RenderMesh
        {
            //mesh = PolygonalMesh(30f, 5),
            mesh = DoubleSidedPolygonalMesh(30f, 10f, 16),
            material = new Material(circleMaterial)
        });
    }
}