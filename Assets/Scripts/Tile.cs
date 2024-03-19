using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileData TileData;

    public GameObject buildingPrefab;

    SourceSystem sourceSystem;

    private void Start()
    {
        sourceSystem = SourceSystem.Instance;
    }

    internal void Build(GameObject prefab)
    {
        if (sourceSystem.RemoveWood(5))
        {
            var bld = Instantiate(prefab, transform);
            //bld.transform.localPosition = Vector3.zero;

            /*Collider collider = GetComponent<Collider>();
            bld.transform.localPosition = new Vector3(bld.transform.position.x + collider.bounds.size.x / 2, bld.transform.position.y, bld.transform.position.z + collider.bounds.size.z / 2);*/
            Vector3 pos = new Vector3(0.5f, 0, 0.5f);
            bld.transform.localPosition = pos;

            TileData.isOccupied = true;
        }
    }

    private void OnMouseDown()
    {
        CommandQueue.Instance.EnqueueCommand(new BuildCommand() { 
            prefab = buildingPrefab, 
            tile = this
        });
    }
}
