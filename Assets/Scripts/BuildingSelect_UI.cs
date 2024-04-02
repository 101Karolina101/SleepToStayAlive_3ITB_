using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSelect_UI : MonoBehaviour
{
    [SerializeField] BuildingsScriptable buildingsData;

    private void Start()
    {
        foreach (var building in buildingsData.buildings)
        {
            var buildingImg = Instantiate(buildingsData.buildingImage, gameObject.transform.GetChild(0));
            Image buildingSprite = buildingImg.GetComponent<Image>();

            buildingSprite.sprite = building.buildingSprite;
        }
    }
}
