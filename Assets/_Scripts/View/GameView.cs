using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using Tools;
using UnityEngine;

public class GameView : MonoBehaviour
{
    [SerializeField] private Transform centreMapPoint;
    [SerializeField] private float spawnZoneRange;
    [SerializeField] private CinemachineVirtualCamera cmCamera;
    private PlayerController playerController;
    private List<RivalsAI> oponentAIs = new();
    private List<Tank> targets = new();
    private GameSaves saves => GameSaves.Instance;
    private GameScreen gameScreen;
    private GameConfigs configs => GameConfigs.Instance;
    public Vector3 GetRandomPointInMap()
    {
        Vector3 point = GetRandomPoint();
        for (int i = 0; i < 1000 && !GameTools.HasGrount(point, configs.settings.rivalsAISettings.whatIsGround); i++)
        {
            point = GetRandomPoint();
        }
        return point;


        Vector3 GetRandomPoint() => RandomTools.GetRandomPointInRange(centreMapPoint.position, spawnZoneRange, useY: false);
    }
    public void Start()
    {
        DynamicGI.UpdateEnvironment();
        var gameScreen = WindowManager.Instance.Show<GameScreen>();
        playerController = CreatePlayer(GetRandomPointInMap(), gameScreen.joystick);
        cmCamera.LookAt = playerController.drone.transform;
        cmCamera.Follow = playerController.drone.transform;
        for (int i = 0; i < configs.settings.maxOponentsInScene; i++)
        {
            oponentAIs.Add(CreateRandomAI(centreMapPoint.position, GetRandomPointInMap()));
        }
        for (int i = 0; i < configs.settings.maxTargetsInScene; i++)
        {
            targets.Add(CreateRandomTarget(GetRandomPointInMap()));
            targets.Last().onLife.AddListener(target =>
            {
                target.agent.Warp(GetRandomPointInMap());
            });
        }
        GameModel gameModel = new GameModel();
        gameScreen.Show(playerController.model, oponentAIs.Select(ai => ai.model).ToList(), gameModel);
        gameModel.Start(GameConfigs.Instance.settings.gameSessionDuration, playerController.model, oponentAIs.Select(ai => ai.model).ToList());
    }
    public static RivalsAI CreateRandomAI(Vector3 centrePosition, Vector3 position)
    {
        PlayerModel model = new(GameConfigs.Instance.settings.oponentNames.GetRandom());

        var drone = Instantiate(ResourceLoader.LoadAllDronePrefabes().GetRandom(), position, Quaternion.identity);
        RivalsAI ai = new RivalsAI(model, GameConfigs.Instance.settings.rivalsAISettings, drone, centrePosition);
        return ai;
    }
    public static PlayerController CreatePlayer(Vector3 position, Joystick joystick)
    {
        PlayerModel playerModel = new("You");

        var drone = Instantiate(ResourceLoader.LoadSelectedDronePrefab(), position, Quaternion.identity);
        Debug.LogError(GameSaves.Instance.selectedDroneName.value);
        var controller = new PlayerController(joystick, drone, playerModel);
        return controller;
    }
    public static Tank CreateRandomTarget(Vector3 position)
    {
        var tank = Instantiate(ResourceLoader.LoadAllTanksPrefabes().GetRandom(), position, Quaternion.identity);
        return tank;
    }
    private void FixedUpdate()
    {
        oponentAIs.ForEach(oa => oa.Update());
        playerController?.Update();
    }

}
