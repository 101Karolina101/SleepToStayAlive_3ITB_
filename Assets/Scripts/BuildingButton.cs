using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButton : MonoBehaviour
{
    public BuildingData buildingData { get; private set; }

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void SetBuildingData(BuildingData data)
    {
        buildingData = data;
    }

    public void SetOnClick()
    {
        gameManager.SetSelectedBuildingData(buildingData);
    }
}
