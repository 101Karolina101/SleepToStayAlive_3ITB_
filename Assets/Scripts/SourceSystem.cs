using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceSystem : MonoBehaviour
{
    public event Action<int> WoodChanged;
    public event Action<int> StoneChanged;

    public static SourceSystem Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public int wood { get; private set; } = 0;
    public int stone { get; private set; } = 0;

    public void AddWood(int amount)
    {
        wood += amount;
        WoodChanged?.Invoke(wood);
    }

    public void AddStone(int amount)
    {
        stone += amount;
        StoneChanged?.Invoke(stone);
    }

    public bool RemoveWood(int amount)
    {
        if (wood >= amount)
        {
            wood -= amount;
            WoodChanged?.Invoke(wood);
            return true;
        }
        return false;
    }

    public bool RemoveStone(int amount)
    {
        if (stone >= amount)
        {
            stone -= amount;
            StoneChanged?.Invoke(stone);
            return true;
        }
        return false;
    }

    public bool RemoveResources(int woodAmount, int stoneAmoutn)
    {
        if(wood >= woodAmount && stone >= stoneAmoutn)
        {
            wood -= woodAmount;
            stone -= stoneAmoutn;
            WoodChanged?.Invoke(wood);
            StoneChanged?.Invoke(stone);
            return true;
        }
        else
        {
            return false;
        }
    }
}
