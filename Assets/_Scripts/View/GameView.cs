using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Tools;
using UnityEngine;

public class GameView : MonoBehaviour
{
    [SerializeField] private Transform centreMapPoint;
    [SerializeField] private float spawnZoneRange;
    [SerializeField] private CinemachineVirtualCamera cmCamera;
    private PlayerModel playerModel;
    private PlayerController playerController;
    private Dron playerDrone;
    private List<PlayerModel> openentModels = new();
    private List<RivalsAI> oponentAIs = new();
    private GameSaves saves => GameSaves.Instance;
    private GameScreen gameScreen;
    public void Start()
    {
        playerModel = new();
        playerDrone = Instantiate(ResourceLoader.LoadSelectedDronePrefab(), RandomTools.GetRandomPointInRange(centreMapPoint.position, spawnZoneRange, useY: false), Quaternion.identity);

        gameScreen = WindowManager.Instance.Show<GameScreen>();
        gameScreen.Show(playerModel);
        playerController = new PlayerController(gameScreen.joystick, playerDrone);

        cmCamera.LookAt = playerDrone.transform;
        cmCamera.Follow = playerDrone.transform;
    }
    public RivalsAI CreateRandomAI()
    {
        RivalsAI ai = new RivalsAI();
        var drone = Instantiate(ResourceLoader.LoadAllDronePrefabes().GetRandom(), RandomTools.GetRandomPointInRange(centreMapPoint.position, spawnZoneRange, useY: false), Quaternion.identity);
        ai.SetDrone(drone);
        return ai;
    }
    private void FixedUpdate()
    {
        oponentAIs.ForEach(oa => oa.Update());
        playerController?.Update();
    }

}
