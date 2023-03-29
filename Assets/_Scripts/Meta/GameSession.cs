using System.Collections;
using System.Collections.Generic;
using Tools;
using Tools.PlayerPrefs;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum GameScenes
{
    MenuScene,
    GameScene
}

public class GameSession : Singleton<GameSession>
{
    public GameModel currentGame;
    public bool isFirstSession
    {
        get { return !PlayerPrefsPro.Get<bool>(nameof(isFirstSession)); }
        private set { PlayerPrefsPro.Set(nameof(isFirstSession), true); }
    }
    public GameSession()
    {
        if (isFirstSession)
        {
            GameSaves.Instance.selectedDroneName.value = ResourceLoader.LoadAllDronePrefabes()[0].name;
        }
    }
    public void StartGame()
    {
        currentGame = new GameModel();
        WindowManager.Instance.CloseAll();
        LoadScene(GameScenes.GameScene);
    }
    private void LoadScene(GameScenes scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
    public void EndGame()
    {
        currentGame = null;
        LoadScene(GameScenes.MenuScene);
    }
}
