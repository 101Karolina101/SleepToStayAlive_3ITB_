using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    //---------------------------------------- ^ singleton stuff

    public event Action<GamePhase> OnGamePhaseChanged;

    public BuildingData selectedBuildingData { get; private set; }

    public GamePhase gamePhase = GamePhase.Building;

    [SerializeField] GameObject player;

    Vector3 cameraPos;
    Vector3 cameraRot;

    private void Start()
    {
        cameraPos = Camera.main.transform.position;
        cameraRot = Camera.main.transform.eulerAngles;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePhase();
        }
    }

    public void SetSelectedBuildingData(BuildingData data)
    {
        selectedBuildingData = data;
    }

    public void TogglePhase()
    {
        switch (gamePhase)
        {
            case GamePhase.Building:
                SetGamePhase(GamePhase.Combat);
                break;
            case GamePhase.Combat:
                SetGamePhase(GamePhase.Building);
                break;
        }
    }

    public void SetGamePhase(GamePhase phase)
    {
        gamePhase = phase;

        switch(gamePhase)
        {
            case GamePhase.Building:
                SetBuildingPhase();

                break;
            case GamePhase.Combat:
                SetCombatPhase();

                break;
        }
    }

    void SetBuildingPhase()
    {
        //aktivní - grid, šedý bar, resources, pryč - player
        player.SetActive(false);
        OnGamePhaseChanged?.Invoke(gamePhase);

        Camera.main.transform.position = cameraPos;
        Camera.main.transform.eulerAngles = cameraRot;
        //TODO deaktivovat mířítko hráče když ho deaktivuji - dát kurzor na volný místo fixed
    }

    void SetCombatPhase()
    {
        //aktivní - player, pryč - grid, šedý bar, resources
        player.SetActive(true);
        OnGamePhaseChanged?.Invoke(gamePhase);
    }
}

public enum GamePhase
{
    Building,
    Combat
}