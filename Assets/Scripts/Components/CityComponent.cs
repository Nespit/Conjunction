﻿using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

// ReSharper disable once InconsistentNaming
[Serializable]
public struct CityComponent : IComponentData
{
    public Vector3 position;
    public City city;
    public int healthyPopulation;
    public int sickPopulation;
    public float moral;
    public int industry;
    public float sicknessRate;
    public int sicknessDetectionLevel;
    public int infrastructureLevel;
    public int quarantineLevel;

    public CityComponent(Vector3 position, City city, int healthyPopulation, int sickPopulation, float moral, int industry, float sicknessRate, int sicknessDetectionLevel, int infrastructureLevel, int quarantineLevel)
    {
        this.position = position;
        this.city = city;
        this.healthyPopulation = healthyPopulation;
        this.sickPopulation = sickPopulation;
        this.moral = moral;
        this.industry = industry;
        this.sicknessRate = sicknessRate;
        this.sicknessDetectionLevel = sicknessDetectionLevel;
        this.infrastructureLevel = infrastructureLevel;
        this.quarantineLevel = quarantineLevel;
    }
}
