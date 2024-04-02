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

    public override void Execute()
    {
        if (tile != null && prefab != null)
        {
            tile.Build(prefab);
        }
    }
}
