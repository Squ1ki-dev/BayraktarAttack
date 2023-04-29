using System.Collections;
using System.Collections.Generic;
using Tools;
using Tools.Reactive;
using UnityEngine;
using UnityEngine.Events;

public class GameModel
{
    public Reactive<int> TimeToEnd = new Reactive<int>();
    private bool isStarted = false;
    public UnityEvent onEnd = new();
    PlayerModel player;
    List<PlayerModel> allPlayers;
    public void Start(int sessionDuration, PlayerModel player, List<PlayerModel> all)
    {
        TimeToEnd.value = sessionDuration;
        this.player = player;
        allPlayers = all;
        StartTimer(sessionDuration);
    }
    private async void StartTimer(int duration)
    {
        while (TimeToEnd.value > 0)
        {
            await TaskTools.WaitForMilliseconds(1000);
            if (!Application.isPlaying) return;
            TimeToEnd.value--;
        }
        End();
    }
    public void End()
    {
        onEnd.Invoke();
        
        // GameSession.Instance.EndGame(this)
        WindowManager.Instance.Show<GameEndScreen>().Show(this, allPlayers, player);
    }
}
