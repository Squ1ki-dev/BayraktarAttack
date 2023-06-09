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
    public void StartGame()
    {
        WindowManager.Instance.CloseAll();
        TinySauce.OnGameStarted();
        LoadScene(GameScenes.GameScene);
    }
    private void LoadScene(GameScenes scene)
    {
        WindowManager.Instance.CloseAll();
        SceneManager.LoadScene(scene.ToString());
    }
    public void EndGame(GameModel model)
    {
        LoadScene(GameScenes.MenuScene);
        //TinySauce.OnGameFinished(model.Scores.value);
    }
}
