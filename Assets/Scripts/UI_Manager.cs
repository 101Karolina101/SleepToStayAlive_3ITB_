using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] GameObject grid;
    [SerializeField] GameObject buildingBar;
    [SerializeField] GameObject resources;

    private void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.OnGamePhaseChanged += OnGamePhaseChanged;
    }

    private void OnGamePhaseChanged(GamePhase phase)
    {
        switch (phase)
        {
            case GamePhase.Building:
                //aktivní - grid, šedý bar, resources, pryč - player
                SetBuildingPhase();
                
                break;
            case GamePhase.Combat:
                //aktivní - player, pryč - grid, šedý bar, resources
                SetCombatPhase();

                break;
        }
    }

    void SetBuildingPhase()
    {
        //grid.SetActive(true);
        buildingBar.SetActive(true);
        resources.SetActive(true);
    }

    void SetCombatPhase()
    {
        //grid.SetActive(false);
        buildingBar.SetActive(false);
        resources.SetActive(false);
    }
}
