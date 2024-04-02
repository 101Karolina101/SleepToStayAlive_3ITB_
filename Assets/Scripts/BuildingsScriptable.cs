using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building Scriptable", menuName = "ScriptableObjects/BuildingsScriptable")]
public class BuildingsScriptable : ScriptableObject
{
    public GameObject buildingImage;
    public List<BuildingData> buildings = new List<BuildingData>();
}

[Serializable]
public class BuildingData
{
    public BuildingType buildingType;
    public string name;
    public string description;
    public int woodCost;
    public int stoneCost;
    //public int coinsCost;
    public GameObject buildingPrefab;
    public Sprite buildingSprite;
}

public enum BuildingType
{
    House,
    Tower,
    Wall
}