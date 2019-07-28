using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CityEntityGenerator : MonoBehaviour
{
    private EntityManager entityManager;

    [SerializeField]
    public City city;

    [SerializeField]
    List<City> connections;

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
    
    private void Start()
    {
        entityManager = World.Active.EntityManager;

        var data = new CityComponent(city, healthyPopulation, sickPopulation, moral, industry, sicknessRate, sicknessDetectionLevel, infrastructureLevel, quarantineLevel);
        var entity = entityManager.CreateEntity();
        entityManager.AddComponentData(entity, data);

        for (int i = 0; i < connections.Count; ++i)
        {
            var dataX = new ConnectionComponent(connections[i]);
            entityManager.AddComponentData(entity, dataX);
        }
    }
}