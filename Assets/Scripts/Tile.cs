using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileData TileData;

    public GameObject buildingPrefab;

    SourceSystem sourceSystem;

    GameManager gameManager;

    private void Start()
    {
        sourceSystem = SourceSystem.Instance;
        gameManager = GameManager.Instance;
    }

    internal void Build(BuildingData buildingData)//GameObject prefab
    {
        //TODO vzít si resource které potřebuju z buldingData
        if (sourceSystem.RemoveResources(buildingData.woodCost, buildingData.stoneCost))//sourceSystem.RemoveWood(5)
        {
            var bld = Instantiate(buildingData.buildingPrefab, transform);
            //bld.transform.localPosition = Vector3.zero;

            Collider collider = GetComponent<Collider>();
            Vector3 pos = new Vector3(collider.bounds.size.x / 2, bld.transform.position.y, collider.bounds.size.z / 2);
            //Vector3 pos = new Vector3(1.025f, 0, 1.025f);
            bld.transform.localPosition = pos;

            TileData.isOccupied = true;

            gameManager.SetSelectedBuildingData(null);
        }
        else
        {
            gameManager.SetSelectedBuildingData(null);
        }
    }

    private void OnMouseDown()
    {
        BuildingData buildingDataOnMouse = gameManager.selectedBuildingData;
        if (buildingDataOnMouse != null)
        {
            CommandQueue.Instance.EnqueueCommand(new BuildCommand()
            {
                buildingData = buildingDataOnMouse,
                tile = this
            });
        }
    }
}
