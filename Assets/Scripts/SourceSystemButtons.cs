using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceSystemButtons : MonoBehaviour
{
    SourceSystem sourceSystem;

    private void Start()
    {
        sourceSystem = SourceSystem.Instance;
    }

    public void AddWood()
    {
        sourceSystem.AddWood(5);
    }

    public void AddStone()
    {
        sourceSystem.AddStone(5);
    }

    public void AddResources()
    {
        sourceSystem.AddWood(500);
        sourceSystem.AddStone(500);
    }
}
