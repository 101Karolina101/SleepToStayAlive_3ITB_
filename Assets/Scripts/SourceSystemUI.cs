using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SourceSystemUI : MonoBehaviour
{
    SourceSystem sourceSystem;

    [SerializeField] TMP_Text woodCount;
    [SerializeField] TMP_Text stoneCount;

    private void Start()
    {
        sourceSystem = SourceSystem.Instance;
        sourceSystem.WoodChanged += OnWoodChanged;
        sourceSystem.StoneChanged += OnStoneChanged;

        OnWoodChanged(sourceSystem.wood);
        OnStoneChanged(sourceSystem.stone);
    }

    private void OnWoodChanged(int amount)
    {
        woodCount.text = "Wood: " + amount.ToString();
    }

    private void OnStoneChanged(int amount)
    {
        stoneCount.text = "Stone: " + amount.ToString();
    }
}
