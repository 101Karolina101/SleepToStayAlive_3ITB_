using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void Execute();
}

public class BuildCommand : Command
{
    public Tile tile;
    public GameObject prefab;

    /*public GameObject woodenPrefab;
    public GameObject stonePrefab;*/

    public override void Execute()
    {
        /*int rnd = Random.Range(0, 2);
        if (rnd == 0)
        {
            prefab = woodenPrefab;
        }
        else
        {
            prefab = stonePrefab;
        }*/

        if (tile != null && prefab != null)
        {
            tile.Build(prefab);
        }
    }
}
