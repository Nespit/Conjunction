using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Rendering;

[ExecuteInEditMode]
public class ConnectionEditor : MonoBehaviour, IConvertGameObjectToEntity
{
    [SerializeField]
    public GameObject cityA;

    [SerializeField]
    public GameObject cityB;

    [SerializeField]
    public Material lineMaterial;

    private void Update()
    {
        Debug.DrawLine(cityA.transform.position, cityB.transform.position, Color.red, 0.0f);

        Vector3 vectorA = cityA.transform.position; Vector3 vectorB = cityB.transform.position; float width = 8f;

            Vector3[] v = new Vector3[4];

            Vector3 norm = Vector3.Normalize(vectorA - vectorB);
            Vector3 perp = Vector3.Cross(norm, Vector3.forward);

            v[0] = vectorA + perp * (width / 2);
            v[1] = vectorA - perp * (width / 2);
            v[2] = vectorB - perp * (width / 2);
            v[3] = vectorB + perp * (width / 2);

        Debug.DrawLine(v[0], v[3], Color.blue, 0.0f);
        Debug.DrawLine(v[3], v[1], Color.blue, 0.0f);
        Debug.DrawLine(v[1], v[0], Color.blue, 0.0f);

        Debug.DrawLine(v[1], v[3], Color.blue, 0.0f);
        Debug.DrawLine(v[3], v[2], Color.blue, 0.0f);
        Debug.DrawLine(v[2], v[1], Color.blue, 0.0f);
    }

    private Mesh CreateLineMesh(Vector3 vectorA, Vector3 vectorB, float width)
    {
        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        Vector3 norm = Vector3.Normalize(vectorA - vectorB);
        Vector3 perp = Vector3.Cross(norm, Vector3.forward);

        vertices[0] = vectorA + perp * (width / 2);
        vertices[1] = vectorA - perp * (width / 2);
        vertices[2] = vectorB - perp * (width / 2);
        vertices[3] = vectorB + perp * (width / 2);

        vertices[2].z = 0;
        vertices[3].z = 0;
        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 1);
        uv[2] = new Vector2(1, 1);
        uv[3] = new Vector2(1, 0);

        triangles[0] = 0;
        triangles[1] = 3;
        triangles[2] = 1;

        triangles[3] = 1;
        triangles[4] = 3;
        triangles[5] = 2;

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        return mesh;
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var a = cityA.GetComponent<CityEntityGenerator>();
        var b = cityB.GetComponent<CityEntityGenerator>();

        var data = new ConnectionComponent
        {
            pointA = a.city,
            pointB = b.city,
            posA = cityA.transform.position,
            posB = cityB.transform.position,
        };

        dstManager.AddComponentData(entity, data);

        dstManager.AddSharedComponentData(entity, new RenderMesh
        {
            mesh = CreateLineMesh(data.posA, data.posB, 8f),
            material = lineMaterial,
        });
    }
}